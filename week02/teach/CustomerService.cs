/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: New customer added -> Helama, A123, Cannot login
        // Expected Result: True, customer is added to queue
        Console.WriteLine("Test 1");

        CustomerService cs = new CustomerService(0);
        cs.AddNewCustomer();
        Console.WriteLine(cs);
        Console.WriteLine("Test 1 Complete");

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Remove customer from queue
        // Expected Result: True, customer is removed from queue
        Console.WriteLine("Test 2");

        CustomerService cs2 = new CustomerService(0);
        cs2.AddNewCustomer();

        Console.WriteLine("Customer inserted");

        cs2.ServeCustomer();

        Console.WriteLine("Test 2 Complete");

        // Defect(s) Found: System.ArgumentOutOfRangeException - Var customer was being accessed after the customer was removed from the queue.

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Trying to add a customer when there is no space in the queue
        // Expected Result: Error message indicating the queue is full
        Console.WriteLine("Test 3");

        CustomerService cs3 = new CustomerService(3);
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        Console.WriteLine(cs3);
        Console.WriteLine("Test 3 Complete");

        // Defect(s) Found: If statment is not being triggered when max size is reached. A >= was missing.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Serve customer when there are no customers in the queue
        // Expected Result: Error message indicating there are no customers to serve

        Console.WriteLine("Test 4");

        CustomerService cs4 = new CustomerService(3);
        cs4.ServeCustomer();
        Console.WriteLine("Test 4 Complete");

        // Defect(s) Found: There was no check to see if the queue was empty before trying to serve a customer.

        Console.WriteLine("=================");

        // Test 5
        // Scenario: If user adds a customer service size of 0 or negative number
        // Expected Result: Default size of 10 is used

        Console.WriteLine("Test 5");
        CustomerService cs5 = new CustomerService(-5);
        Console.WriteLine(cs5);
        Console.WriteLine("Test 5 Complete");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in queue to serve.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}