﻿using APINegocio.Aplications.Dtos;
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

            //POST/Payments
            CreateMap<PaymentsPOSTDto, Payments>().ReverseMap();

            //PUT/ Payments
            CreateMap<PaymentsPUTDto, Payments>().ReverseMap();

            //GET/ Payments
            CreateMap<PaymentsDto, Payments>().ReverseMap();

            //GET/PRODUCTOS
            CreateMap<ProductosDto, Productos>().ReverseMap();

            //POST/PRODUCTOS
            CreateMap<ProductosPOSTDto, Productos>().ReverseMap();

            //PUT/PRODUCTOS
            CreateMap<ProductoPUTDto, Productos>().ReverseMap();

            /*Mapper GET o LIST
            CreateMap<ProductosGetDto, Productos>(); este Dto no esta creado, solo esta en caso de ser necesario*/

            //POST/BranchOffices 
            CreateMap<BranchOfficesPOSTDto, BranchOffices>().ReverseMap();

            //PUT/BranchOffices
            CreateMap<BranchOfficesPUTDto, BranchOffices>().ReverseMap();

            //GET/BranchOffices
            CreateMap<BranchOfficesDto, BranchOffices>().ReverseMap();

            //POST/PROVEEDORES
            CreateMap<ProveedoresPOSTDto, Proveedores>().ReverseMap();

            //PUT/PRVEEDORES
            CreateMap<ProveedoresPUTDto, Proveedores>();

            //GET/PRVEEDORES
            CreateMap<ProveedoresDto, Proveedores>().ReverseMap();

            //POST/CUSTOMER
            CreateMap<CustomerPOSTDto, Customers>();

            //PUT/CUSTOMER
            CreateMap<CustomerPUTDto, Customers>();

            //POST/SHOPPING
            CreateMap<ShoppingPOSTDto, Shopping>().ReverseMap();

            //PUT/SHOPPING
            CreateMap<ShoppingPUTDto, Shopping>().ReverseMap();

            //GET/SHOPPING
            CreateMap<ShoppingDto, Shopping>().ReverseMap();

            //POST/Stores
            CreateMap<StoresPOSTDto, Stores>().ReverseMap();

            //PUT/Stores
            CreateMap<StoresPUTDto, Stores>().ReverseMap();

            //GET/Inventory
            CreateMap<InventoryDto, Inventory>().ReverseMap();

            //PUT/SHOPPING
            CreateMap<ShoppingPUTDto, Shopping>();

            //POST/SENDERS
            CreateMap<SendersPOSTDto, Senders>();

            //PUT/SENDERS
            CreateMap<SendersPUTDto, Senders>();

            //GET/SENDERS
            CreateMap<SendersDto, Senders>().ReverseMap();

            //POST/ORDERS
            CreateMap<OrdersPOSTDto, Orders>();

            //PUT/ORDERS
            CreateMap<OrdersPUTDto, Orders>();

            //POST/TICKERS
            CreateMap<TickersPOSTDto, Tickers>();

            //PUT/TICKERS
            CreateMap<TickersPUTDto, Tickers>();

            CreateMap<TickersDto, Tickers>().ReverseMap();

            //POST/Inventory
            CreateMap<InventoryPOSTDto, Inventory>();

            //PUT/Inventory
            CreateMap<InventoryPUTDto, Inventory>();

            //POST/City
            CreateMap<CityPOSTDto, City>().ReverseMap();

            //PUT/City 
            CreateMap<CityPUTDto, City>().ReverseMap();

            //POST/Countries 
            CreateMap<CountriesPOSTDto, Countries>().ReverseMap();

            //PUT/Countries 
            CreateMap<CountriesPUTDto, Countries>().ReverseMap();
        }
    }
}
