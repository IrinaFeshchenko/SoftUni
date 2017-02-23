use MinionsDB

select v.Name, count(vm.MinionId) as minionsCount
from Villains v
join VillainsMinions vm on  vm.VillainId = v.Id
group by v.Name
having count(vm.MinionId) > 3
order by minionsCount desc