namespace APINegocio.Aplications.Dtos
{
    public partial class OperacionesDto
    {
        public int OperacionId { get; set; }
        public string Tipo { get; set; }
        public string Producto { get; set; }
        public DateTime? Fecha { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
       
    }

    public partial class OperacionesPOSTDto
    {
        public string Tipo { get; set; }
        public string Producto { get; set; }
        public DateTime? Fecha { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        
    }

    public partial class OperacionesPUTDto 
    {

        public int OperacionId { get; set; }
        public string Tipo { get; set; }
        public string Producto { get; set; }
        public DateTime? Fecha { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }

    }
}
