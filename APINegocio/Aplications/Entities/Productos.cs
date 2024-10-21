 using System;

namespace APINegocio.Aplications.Entities
{
    public partial class Productos
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Referencia { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; } //= default(DateTime); //PASA LA FECHA ACTUAL DEFAULT
        public bool IsAsset { get; set; } //PARA SABER SI UN PRODUCTO ESTA ACTIVO O NO
        public bool IsDeleted { get; set; }  //PARA SABER SI UN PRODUCTO FUE ELIMINADO
        public DateTime? IsDeletedAt { get; set; } //New
        public bool IsApproved { get; set; }
        public DateTime? IsDateModified { get; set; }
        public bool IsModified { get; set; }
        public DateTime? IsApprovedAt { get;set; } //Agregado 26/06/24
        public string ProductCode { get; set; }  //Agregado 26/06/24
    }
}
