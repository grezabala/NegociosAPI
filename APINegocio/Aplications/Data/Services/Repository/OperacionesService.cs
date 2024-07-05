using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using APINegocio.Aplications.Services.Interfaz.IContext;
using AutoMapper;

namespace APINegocio.Aplications.Data.Services.Repository
{
    public class OperacionesService : IOperacionesService
    {
        public IAPINegocioDbContext _db { get; init; }
        public IMapper _mapper { get; init; }

        public OperacionesService(IAPINegocioDbContext aPINegocioDbContext, IMapper mapper )
        {
            _db = aPINegocioDbContext;
            _mapper = mapper;
        }

        public OperacionesPOSTDto IsCread(OperacionesPOSTDto pOSTDto)
        {
            try
            {
                if(pOSTDto == null)
                    throw new ArgumentNullException("Error! El formulario esta vacio.");

                var operacion = _mapper.Map<Operaciones>(pOSTDto);
                _db.Operaciones.Add(operacion);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsDeleted(OperacionesDto operacionesDto)
        {
            throw new NotImplementedException();
        }

        public OperacionesPUTDto IsUpdated(OperacionesPUTDto pUTDto)
        {
            throw new NotImplementedException();
        }

        public ICollection<OperacionesDto> GetOperacionesDtos()
        {
            throw new NotImplementedException();
        }

        public OperacionesDto GetOperacionesDtoById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
