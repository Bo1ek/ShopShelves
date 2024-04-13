using ShopShelves;

Console.WriteLine("Please provide a number of Shelves");
var numberOfShelves = Console.ReadLine().Trim();

//create list of threads so we can wait for all of them to finish the job and give user a response that all threads ends their job
List<Thread> threads = new List<Thread>();



//Invoking a validation and checking if the numbers are valid or no
while (!int.TryParse(numberOfShelves, out int result) || result <= 0)
{
    Console.WriteLine("Please provide a number of Shelves");
    numberOfShelves = Console.ReadLine().Trim();

}

var validatedNumberOfShelves = int.Parse(numberOfShelves);
var warehouseMan = new Warehouseman();

//Creating threads for every shelf in the shop
for (int i = 0; i < validatedNumberOfShelves; i++)
{
    var currentShelveNumber = i + 1;
    var thread = new Thread(() =>
    {
        ClientsIsShelve(currentShelveNumber, warehouseMan);
    });

    //Here we will start all threads to work
    thread.Start();
    threads.Add(thread);
}



// Wait for all threads to finish
foreach (var thread in threads)
{
    thread.Join();
}

Console.WriteLine("All clients ends their shopping");


//Method for generating number of products in single shelf
static int GenerateNumberOfProductTypesInShelf()
{
    var random = new Random();
    return random.Next(1, 5);
}

static int GenerateNumberOfClientsInQueueToShelf()
{
    var random = new Random();
    return random.Next(1, 5);
}


static void ClientsIsShelve(int currentShelveNumber, Warehouseman warehouseman)
{
    //This code will be done in single thread

    var shelf = new Shelf();
    //Generate number of products in shelf, the number is between 1 and 10
    var numberOfProductTypesInShelf = GenerateNumberOfProductTypesInShelf();

    //Adding products to list of a products, so they are on shelf now
    for (int i = 0; i < numberOfProductTypesInShelf; i++)
    {
        shelf.productsOnShelf.Add(new ProductType());
    }
    //generate amount of clients iin queue to shelf
    var numberOfClientsInQueueToShelf = GenerateNumberOfClientsInQueueToShelf();
    //Create a list of clients in queue to shelf
    var clientsInQueueToShelf = new List<Client>();

    //Adding clients to list
    for (int i = 0; i < numberOfClientsInQueueToShelf; i++)
    {
        clientsInQueueToShelf.Add(new Client(i));
    }

    foreach (var client in clientsInQueueToShelf)
    {
        //checking if client is still in the shop
        if (!client.didClientLeftTheShop)
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, shelf.productsOnShelf.Count);
            Console.WriteLine("Client number " + (client.clientId + 1) + " starts taking products in shelf number " + currentShelveNumber);
            Thread.Sleep(client.howMuchProductsHeNeeds * 100);
            shelf.productsOnShelf[randomIndex].productsAmount -= client.howMuchProductsHeNeeds;
            Console.WriteLine("Client number " + (client.clientId + 1) + " ends taking products in shelf number" + currentShelveNumber);

            //checking if any products amount drop to 0
            if (shelf.productsOnShelf.Any(x => x.productsAmount <= 0))
            {

                lock (warehouseman)
                {
                    if (!warehouseman.isBusy)
                    {
                        //if he is not busy we are changing his state, because now he will be busy :) 
                        warehouseman.isBusy = true;
                        Console.WriteLine("Start replacing products in shelf number " + currentShelveNumber);

                        //Dropping clients patiency
                        foreach (var person in clientsInQueueToShelf)
                        {
                            if (!person.isPatient)
                            {
                                person.timeBeforeResignation -= 200;
                            }
                        }

                        //Delete cliets from list when their patiency is below or equal 0
                        if (clientsInQueueToShelf.Any(x => x.timeBeforeResignation <= 0))
                        {
                            Console.WriteLine(clientsInQueueToShelf.Select(x => x.timeBeforeResignation <= 0).Count() + " Clients in shelf " + currentShelveNumber + " left the queue");

                            clientsInQueueToShelf.Where(x => x.timeBeforeResignation <= 0).ToList().ForEach(x => x.didClientLeftTheShop = true);

                        }

                        //Time he needs to complete the process of adding products to shelf
                        Thread.Sleep(500);

                        //Adding products to shelf
                        shelf.productsOnShelf.Where(x => x.productsAmount == 0).ToList().ForEach(x => x.productsAmount = 10);

                        Console.WriteLine("Ends replacing products in shelf number " + currentShelveNumber);

                        //Warehouseman finished his job
                        warehouseman.isBusy = false;
                    }

                }
            }
        }


    }



    Console.WriteLine("****");
    Console.WriteLine("*************");
    Console.WriteLine("****************No more clients in shelf number*********" + currentShelveNumber);
    Console.ReadKey();
}