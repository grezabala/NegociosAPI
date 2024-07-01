namespace APINegocio.Aplications.Dtos
{
    public class ProductosPOSTDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Referencia { get; set; }
        //public DateTime? CreatedDate { get; set; } //= default(DateTime); //PASA LA FECHA ACTUAL DEFAULT
        public string ProductCode { get; set; }
       // public bool IsAsset { get; set; } //PARA SABER SI UN PRODUCTO ESTA ACTIVO O NO
        //public bool IsDeleted { get; set; }  //PARA SABER SI UN PRODUCTO FUE ELIMINADO
        //public DateTime? IsDeletedAt { get; set; }  //PARA SABER SI UN PRODUCTO FUE ELIMINADO EN QUE FECHA
       // public bool IsApproved { get; set; }
        //public DateTime? IsApprovedAt { get; set; }
       // public DateTime? IsDateModified { get; set; }
        //public bool IsModified { get; set; }


    }
    public class ProductoPOST 
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Referencia { get; set; }
        public string ProductCode { get; set; }

    }

}
