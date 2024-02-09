

using TaskDataBaseSql.Services;

namespace ApplicationSql.Service
{
    public class PlayerMenuUI
    {
        private readonly ClientService _clientService;
        private readonly UserService _userService;

        public PlayerMenuUI(ClientService clientService, UserService userService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        public void CreatePlayer()
        {
            Console.WriteLine("---Create Player---");

            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;

            Console.Write("Street Name: ");
            var streetName = Console.ReadLine()!;

            Console.Write("Postal Code: ");
            var postalCode = Console.ReadLine()!;

            Console.Write("City: ");
            var city = Console.ReadLine()!;

            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine()!;

            Console.Clear();

            var result = _clientService.CreateClient(firstName, lastName, streetName, postalCode, city, email, phoneNumber);

            if (result != null)
            {
                Console.WriteLine("Client details created successfully.");
                Console.WriteLine("---Player Identity---");
                Console.WriteLine("Please provide the following details for your game profile.");

                Console.Write("Player Name: ");
                var playerName = Console.ReadLine()!;

                Console.Write("Status: ");
                var status = Console.ReadLine()!;

                Console.Write("Role Name: ");
                var roleName = Console.ReadLine()!;

                var user = _userService.CreateUser(playerName, status, roleName);

                if (user != null)
                {
                    Console.WriteLine("Game profile created successfully.");
                }
                else
                {
                    Console.WriteLine("Error creating game profile. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Error creating client details. Please try again.");
            }

            Console.ReadKey();
        }

        public void GetPlayer()
        {
            Console.WriteLine("---List of Players---");

            var players = _clientService.GetAllClients();

            foreach (var player in players)
            {
                Console.WriteLine($"{player.FirstName} - {player.LastName} - {player.Address.StreetName} - {player.Address.PostalCode} - {player.Address.City} - {player.Contact.Email} - {player.Contact.PhoneNumber}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void UpdatePlayer()
        {
            Console.WriteLine("---Update Player---");

            Console.Write("Enter Player ID: ");
            var id = int.Parse(Console.ReadLine()!);

            var client = _clientService.GetClientById(id);

            if (client != null)
            {
                Console.WriteLine($"Current Player Details: {client.FirstName} - {client.LastName} - {client.Address.StreetName} - {client.Address.PostalCode} - {client.Address.City} - {client.Contact.Email} - {client.Contact.PhoneNumber}");
                Console.WriteLine();

                Console.Write("New First Name: ");
                client.FirstName = Console.ReadLine()!;

                var updatedPlayer = _clientService.UpdateClient(client);
                Console.WriteLine($"Updated Player Details: {updatedPlayer.FirstName} - {updatedPlayer.LastName} - {updatedPlayer.Address.StreetName} - {updatedPlayer.Address.PostalCode} - {updatedPlayer.Address.City} - {updatedPlayer.Contact.Email} - {updatedPlayer.Contact.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("No Player Found");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DeletePlayer()
        {
            Console.Write("Enter Player ID: ");
            var id = int.Parse(Console.ReadLine()!);

            var client = _clientService.GetClientById(id);

            if (client != null)
            {
                _clientService.DeleteClient(client.Id);
                Console.WriteLine("Player Was Deleted");
            }
            else
            {
                Console.WriteLine("Player was not Deleted");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public void GetUser()
        {
            Console.WriteLine("---List of Users---");

            var users = _userService.GetAllUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.PlayerName} - {user.Status} - {user.RoleId}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void UpdateUser()
        {
            Console.WriteLine("---Update User---");

            Console.Write("Enter User ID: ");
            var id = int.Parse(Console.ReadLine()!);

            var user = _userService.GetUserById(id);

            if (user != null)
            {
                Console.WriteLine($"Current User Details: {user.PlayerName} - {user.Status} - {user.RoleId}");
                Console.WriteLine();

                Console.Write("New Player Name: ");
                user.PlayerName = Console.ReadLine()!;
                Console.Write("New Status: ");
                user.Status = Console.ReadLine()!;
                Console.Write("New Role Id: ");
                user.RoleId = Console.ReadLine()!;

                var updatedUser = _userService.UpdateUser(user);
                Console.WriteLine($"Updated User Details: {updatedUser.PlayerName} - {updatedUser.Status} - {updatedUser.RoleId}");
            }
            else
            {
                Console.WriteLine("No User Found");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DeleteUser()
        {
            Console.Write("Enter User ID: ");
            var id = int.Parse(Console.ReadLine()!);

            var user = _userService.GetUserById(id);

            if (user != null)
            {
                _userService.DeleteUser(user.Id);
                Console.WriteLine("User Was Deleted");
            }
            else
            {
                Console.WriteLine("User was not Deleted");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}





//using TaskDataBaseSql.Services;

//namespace ApplicationSql.Service
//{
//    public class PlayerMenuUI
//    {
//        private readonly ClientService _clientService;

//        public PlayerMenuUI(ClientService clientService)
//        {
//            _clientService = clientService;
//        }

//        public void CreatePlayer()
//        {
//            Console.Clear();

//            Console.WriteLine("---Create Player---");

//            Console.Write("First Name: ");
//            var firstname = Console.ReadLine()!;

//            Console.Write("Last Name: ");
//            var lastname = Console.ReadLine()!;

//            Console.Write("StreetName: ");
//            var streetname = Console.ReadLine()!;

//            Console.Write("PostalCode: ");
//            var postalcode = Console.ReadLine()!;

//            Console.Write("City: ");
//            var city = Console.ReadLine()!;

//            Console.Write("Email: ");
//            var email = Console.ReadLine()!;

//            Console.Write("PhoneNumber: ");
//            var phoneNumber = Console.ReadLine()!;

//            var result = _clientService.CreateClient(firstname, lastname,streetname,postalcode,city,email,phoneNumber);    
//            if (result != null)
//            {
//                Console.Clear();
//                Console.WriteLine("Player was create");

//                Console.ReadKey();  
//            }
//        }

//        public void GetPlayer()
//        {
//            Console.Clear();
//            var player = _clientService.GetAllClients();

//            foreach (var client in player)
//            {
//                Console.Clear();
//                Console.WriteLine($"{client.FirstName} - {client.LastName} - {client.Address.StreetName} - {client.Address.PostalCode} - {client.Address.City} - {client.Contact.Email} - {client.Contact.PhoneNumber}");

//            }
//            Console.ReadKey();
//        }

//        public void UpdatePlayer()
//        {
//            Console.Clear();
//            Console.Write("Enter Id: ");
//            var id = int.Parse(Console.ReadLine()!);
//            var client = _clientService.GetClientById(id);

//            if (client != null)
//            {
//                Console.WriteLine($"{client.FirstName} - {client.LastName} - {client.Address.StreetName} - {client.Address.PostalCode} - {client.Address.City} - {client.Contact.Email} - {client.Contact.PhoneNumber}");
//                Console.WriteLine();

//                Console.Write("New Player Name: ");
//                client.FirstName = Console.ReadLine()!;

//                var newPlayer = _clientService.UpdateClient(client);
//                Console.WriteLine($"{client.FirstName} - {client.LastName} - {client.Address.StreetName} - {client.Address.PostalCode} - {client.Address.City} - {client.Contact.Email} - {client.Contact.PhoneNumber}");


//            }
//            else 
//            {

//                Console.WriteLine("No Player Found");

//            }
//            Console.ReadKey();
//        }




//    }
//}