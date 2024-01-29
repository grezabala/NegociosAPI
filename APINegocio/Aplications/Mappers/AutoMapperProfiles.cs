using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using AutoMapper;

namespace APINegocio.Aplications.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            /*
             * Class para Mapper la entity
             * 
             * ReverseMap --Indica que va a Mapper de ProductosAddDto o que va a Mapper de Producto a ProductosAddDto. 
             En caso de ser necesario            
             */

            #region MAPPER USERS
            CreateMap<UsersRegisterDto, Users>();
            CreateMap<UsersLoginDto, Users>();
            CreateMap<Users, UsersListDto>();
            #endregion

            //POST/PRODUCTOS
            CreateMap<ProductosPOSTDto, Productos>();

            //PUT/PRODUCTOS
            CreateMap<ProductoPUTDto, Productos>();

            /*Mapper GET o LIST
            CreateMap<ProductosGetDto, Productos>(); este Dto no esta creado, solo esta en caso de ser necesario*/

            //POST/PROVEEDORES
            CreateMap<ProveedoresPOSTDto, Proveedores>();

            //PUT/PRVEEDORES
            CreateMap<ProveedoresPUTDto, Proveedores>();

            //POST/CUSTOMER
            CreateMap<CustomerPOSTDto, Customers>();

            //PUT/CUSTOMER
            CreateMap<CustomerPUTDto, Customers>();

            //POST/SHOPPING
            CreateMap<ShoppingPOSTDto, Shopping>();

            //PUT/SHOPPING
            CreateMap<ShoppingPUTDto, Shopping>();

            //POST/SENDERS
            CreateMap<SendersPOSTDto, Senders>();

            //PUT/SENDERS
            CreateMap<SendersPUTDto, Senders>();

            //POST/ORDERS
            CreateMap<OrdersPOSTDto, Orders>();

            //PUT/ORDERS
            CreateMap<OrdersPUTDto, Orders>();

            //POST/TICKERS
            CreateMap<TickersPOSTDto, Tickers>();

            //PUT/TICKERS
            CreateMap<TickersPUTDto, Tickers>();

            //POST/Inventory
            CreateMap<InventoryPOSTDto, Inventory>();

            //PUT/Inventory
            CreateMap<InventoryPUTDto, Inventory>();
        }
    }
}
