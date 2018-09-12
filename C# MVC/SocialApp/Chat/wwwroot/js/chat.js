$(document).ready(() => {

	var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

	connection.on("ReceiveMessage", function (user, message, avatar) {
		var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
		var li = '<li class="chatMessage"><img src="' + avatar + '" alt="Image" class="messageAvatar" /><div class="message">' + message + '<div></li>';
		$('#messages').prepend(li);
		$('#messages li:first').hide().fadeIn(2000);
	});

	connection.start().catch(function (err) {
		return console.error(err.toString());
	});

	$('.chatContact').on('click', 'div', function () {
		let selectedProfileId = this.id;

		$.ajax({
			type: 'POST',
			url: 'Profile/AjaxGetProfileInfo',
			dataType: "json",
			data: { selectedId: selectedProfileId },
			success: successFunc,
			error: errorFunc
		});

		function successFunc(data) {
			$('#profileImage').attr('src', data.avatar);
			$('#profileName').text('Name: ' + data.name);
			$('#profileEmail').text('Email: ' + data.email);
			$('#profileRegisteredOn').text('Registered: ' + data.registeredOn);
			$('#profileContactsCount').text('Contacts: ' + data.contactsCount);
			$('#profileInfoPanel').removeClass('hidden');
			$('#FriendId').val(selectedProfileId);
		}

		function errorFunc() {
		}
	});

	$('#removeContact').on('click', function () {
		let friendId = $('#FriendId').val();
		let userId = Model_Id;

		$.ajax({
			type: 'POST',
			url: 'Profile/AjaxRemoveContact',
			dataType: "json",
			data: { contactId: friendId, userId: userId },
			success: successFunc,
			error: errorFunc
		});

		function successFunc(data) {
			$('#profileInfoPanel').addClass('hidden');
			$('#' + friendId).parent().remove();
		}

		function errorFunc() {
		}

	});

	$('#send-message').on('click', function () {

		let message = $('#message').val();
		let user = Model_NickName;
		let avatar = Model_Avatar;
		let friends = [];

		$("#friendsList").find("div").each(function () { friends.push(this.id); });
		console.log(friends);

		friends = JSON.stringify(friends);
		console.log(friends);

		$('#message').val('');

		if (message) {

			$('#messages').prepend('<li class="chatMessageMine"><img src="' + avatar + '" alt="Image" class="messageAvatarMine" /><div class="messageMine">' + message + '<div></li>');
			$('#messages li:first').hide().fadeIn(2000);

			connection.invoke("SendMessage", user, message, avatar, friends).catch(function (err) {
				return console.error(err.toString());
			});
			event.preventDefault();
		}
	});
});