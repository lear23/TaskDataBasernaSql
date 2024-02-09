

using TaskDataBaseSql.ProductService;

namespace ApplicationSql.Service
{
    public  class ProductServiceUI
    {

        private readonly ProductService _productService;
        private readonly ClientsService _clientService;

        public ProductServiceUI(ProductService productService, ClientsService clientService)
        {
            _productService = productService;
            _clientService = clientService;
        }
               

        public void CreateBuyerUI()
        {
            Console.Clear();

            Console.WriteLine("---Create Player---");

            Console.Write("First Name: ");
            var firstname = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastname = Console.ReadLine()!;


            Console.Write("user Name: ");
            var readerName = Console.ReadLine()!;

            Console.Write("StreetName: ");
            var streetname = Console.ReadLine()!;

            Console.Write("PostalCode: ");
            var postalcode = Console.ReadLine()!;

            Console.Write("City: ");
            var city = Console.ReadLine()!;


            var result = _clientService.CreateClient(firstname, lastname,readerName, streetname, postalcode, city);
            if (result != null)
            {
                Console.Clear();
                Console.WriteLine("Player was create");

                Console.ReadKey();
            }
        }

        public void GetBuyer()
        {
            Console.Clear();
            var player = _clientService.GetAllClients();

            foreach (var client in player)
            {
                Console.Clear();
                string firstName = client.FirstName ?? "Unknown";
                string lastName = client.LastName ?? "Unknown";
                string readerName = client.Reader?.ReaderName ?? "Unknown";
                string streetName = client.Direction?.StreetName ?? "Unknown";
                string postalCode = client.Direction?.PostalCode ?? "Unknown";
                string city = client.Direction?.City ?? "Unknown";

                Console.WriteLine($"{firstName} - {lastName} - {readerName} - {streetName} - {postalCode} - {city}");
            }

            Console.ReadKey();

        }

        public void UpdateBayer()
        {
            Console.Clear();
            Console.Write("Enter Id: ");
            var id = int.Parse(Console.ReadLine()!);
            var client = _clientService.GetClientById(id);

            if (client != null)
            {
                Console.WriteLine($"{client.FirstName} - {client.LastName} - {client.Reader.ReaderName} - {client.Direction.StreetName} - {client.Direction.PostalCode} - {client.Direction.City}");
                Console.WriteLine();

                Console.Write("New Player Name: ");
                client.FirstName = Console.ReadLine()!;

                var newPlayer = _clientService.UpdateClient(client);
                Console.WriteLine($"{client.FirstName} - {client.LastName} - {client.Reader.ReaderName} - {client.Direction.StreetName} - {client.Direction.PostalCode} - {client.Direction.City}");


            }
            else
            {

                Console.WriteLine("No Player Found");

            }
            Console.ReadKey();
        }








    }
}
