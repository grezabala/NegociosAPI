namespace APINegocio.Aplications.Dtos
{
    public class CustomerPOSTDto
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Direction { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime IsUpdatedDate { get; }
        public bool IsDeleted { get; set; }
        public bool IsStatu { get; set; }
        public bool IsModified { get; set; }

        public CustomerPOSTDto()
        {
            CreatedDate = DateTime.Now;
            IsUpdatedDate = DateTime.MaxValue;
            IsDeleted = false;
            IsStatu = true;
            IsModified = false;

        }
        /*
                {
                  "customerName": "Feliz Díaz Ruíz",
                  "customerEmail": "diazruizfeliz@gmail.com",
                  "customerPhone": "809-895-8958",
                  "direction": "Av. Independecia, calle/ Primera de la Paz, Edif#12A",
                  "city": "Santo Domingo, D.N",
                  "postalCode": "0101",
                  "country": "Republica Dominicana",
                  "createdDate": "2023-07-30T19:24:52.628Z",
                  "isDeleted": false,
                  "isStatu": true,
                  "isModified": false
                }
         */


    }
}
