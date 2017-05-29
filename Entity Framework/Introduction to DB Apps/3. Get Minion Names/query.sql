select v.Name as villainName, m.Name as minionName, m.Age as age
from Villains v
join VillainsMinions vm on vm.VillainId = v.Id
join Minions m on m.Id = vm.MinionId
where v.Id = @villainId