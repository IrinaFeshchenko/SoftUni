function move(command) {
    let aTownList = $('#available-towns');
    let sTownList = $('#selected-towns');
    let outputDiv = $('#output');

    if(command === 'right') {
        sTownList.append(aTownList.find(':selected'));
    } else if(command === 'left') {
        aTownList.append(sTownList.find(':selected'));
    }else{
        let allTowns = sTownList.find('option')
                .toArray()
                .map(x=>x.textContent)
                .join('; ');

        outputDiv.empty();
        outputDiv.append(allTowns);
    }
  }