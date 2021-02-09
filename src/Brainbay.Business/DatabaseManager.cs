using Brainbay.Common;
using Brainbay.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbay.Business
{
    public class DatabaseManager
    {
        private IEpisodeBusiness _episodeBusiness;
        private ICharacterBusiness _characterBusiness;
        private ICharacterTypeBusiness _characterTypeBusiness;
        private IStatusBusiness _statusBusiness;
        private IOriginBusiness _originBusiness;
        private ILocationBusiness _locationBusiness;
        private IGenderBusiness _genderBusiness;
        private ISpeciesBusiness _speciesBusiness;

        public event EventHandler DatabaseClearing;
        public event EventHandler DatabaseCleared;
        public event EventHandler DatabaseUpdating;
        public event EventHandler DatabaseUpdated;



        public DatabaseManager( IEpisodeBusiness episodeBusiness, 
                            ICharacterBusiness characterBusiness, 
                            ICharacterTypeBusiness characterTypeBusiness,
                            IStatusBusiness statusBusiness,
                            IOriginBusiness originBusiness,
                            ILocationBusiness locationBusiness,
                            IGenderBusiness genderBusiness,
                            ISpeciesBusiness speciesBusiness)
        {
            _episodeBusiness = episodeBusiness;
            _characterBusiness = characterBusiness;
            _characterTypeBusiness = characterTypeBusiness;
            _statusBusiness = statusBusiness;
            _originBusiness = originBusiness;
            _locationBusiness = locationBusiness;
            _genderBusiness = genderBusiness;
            _speciesBusiness = speciesBusiness;
        }

        public OperationResult<bool> ClearDatabase()
        {
            DatabaseClearing?.Invoke(this, new EventArgs()); 
            _episodeBusiness.DeleteAll();
            _characterBusiness.DeleteAll();
            _characterTypeBusiness.DeleteAll();
            _statusBusiness.DeleteAll();
            _originBusiness.DeleteAll();
            _locationBusiness.DeleteAll();
            _genderBusiness.DeleteAll();
            _speciesBusiness.DeleteAll();

            DatabaseCleared?.Invoke(this, new EventArgs());
            return new OperationResult<bool>() { Message = null, Status = OperationStatus.Succeeded , Result = true }; 
        }

        public async Task<OperationResult<bool>> ClearDatabaseAsync()
        {
            DatabaseClearing?.Invoke(this, new EventArgs());
            await _episodeBusiness.DeleteAllAsync();
            await _characterBusiness.DeleteAllAsync();
            await _characterTypeBusiness.DeleteAllAsync();
            await _statusBusiness.DeleteAllAsync();
            await _originBusiness.DeleteAllAsync();
            await _locationBusiness.DeleteAllAsync();
            await _genderBusiness.DeleteAllAsync();
            await _speciesBusiness.DeleteAllAsync();

            DatabaseCleared?.Invoke(this, new EventArgs());
            return new OperationResult<bool>() { Message = null, Status = OperationStatus.Succeeded, Result = true };
        }

        public OperationResult<bool> UpdateDatabase(IEnumerable<CharacterDto> serviceResult)
        {
            DatabaseUpdating?.Invoke(this, new EventArgs());
            var characters = extract(serviceResult);
            _characterBusiness.SaveAll(characters);
            DatabaseUpdated?.Invoke(this, new EventArgs());

            return new OperationResult<bool>() { Message = null, Status = OperationStatus.Succeeded, Result = true };
        }

        public async Task<OperationResult<bool>> UpdateDatabaseAsync(IEnumerable<CharacterDto> serviceResult)
        {
            DatabaseUpdating?.Invoke(this, new EventArgs());
            var characters = extract(serviceResult);
            await _characterBusiness.SaveAllAsync(characters);
            DatabaseUpdated?.Invoke(this, new EventArgs());
            return new OperationResult<bool>() { Message = null, Status = OperationStatus.Succeeded, Result = true };
        }

        private IEnumerable<Character> extract(IEnumerable<CharacterDto> serviceResult)
        {
            var genderQuery = serviceResult.GroupBy(e => e.gender).Select(e => new Gender() { ID = Guid.NewGuid(), Name = e.Key });
            var speciesQuery = serviceResult.GroupBy(e => e.species).Select(e => new Species() { ID = Guid.NewGuid(), Name = e.Key });
            var statusQuery = serviceResult.GroupBy(e => e.status).Select(e => new Status() { ID = Guid.NewGuid(), Name = e.Key });
            var charTypeQuery = serviceResult.GroupBy(e => e.type).Select(e => new CharacterType() { ID = Guid.NewGuid(), Name = e.Key });
            var originQuery = serviceResult.Select(e => e.origin).GroupBy(e => new { e.name, e.url }).Select(e => new Origin() { ID = Guid.NewGuid(), Name = e.Key.name, Url = e.Key.url });
            var locationQuery = serviceResult.Select(e => e.location).GroupBy(e => new { e.name, e.url }).Select(e => new Location() { ID = Guid.NewGuid(), Name = e.Key.name, Url = e.Key.url });


            var characters = from i in serviceResult
                             join g in genderQuery on i.gender equals g.Name
                             join s in speciesQuery on i.species equals s.Name
                             join ss in statusQuery on i.status equals ss.Name
                             join ct in charTypeQuery on i.type equals ct.Name
                             join o in originQuery on i.origin.name equals o.Name
                             join l in locationQuery on i.location.name equals l.Name
                             select new Character()
                             {
                                 ID = Guid.NewGuid(),
                                 Name = i.name,
                                 Image = i.image,
                                 Url = i.url,
                                 Gender = g,
                                 Species = s,
                                 Status = ss,
                                 Origin = o,
                                 Location = l,
                                 CharacterType = ct,
                                 Created = DateTime.Parse(i.created),
                                 Episodes = i.episode.Select(e => new Episode() { ID = Guid.NewGuid(), Url = e }).ToList()
                             };

            return characters;
        }
    }
}
