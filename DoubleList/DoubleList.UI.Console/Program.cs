
using DoubleList;

        var list = new DoublyLinkedList<string>();
        string option;
        do
        {
            option = ShowMenu();
            switch (option)
            {
                case "1":
                    Console.Write("Enter item to add (will be inserted in ascending order): ");
                    var newItem = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newItem))
                    {
                        list.Insert(newItem);
                        Console.WriteLine("Item added.");
                    }
                    break;

                case "2":
                    Console.WriteLine("List (forward):");
                    Console.WriteLine(list.GetForward());
                    break;

                case "3":
                    Console.WriteLine("List (backward):");
                    Console.WriteLine(list.GetBackward());
                    break;

                case "4":
                    list.SortDescending();
                    Console.WriteLine("List sorted in descending order.");
                    break;

                case "5":
                    var modes = list.GetMode();
                    Console.WriteLine("Mode(s): " + (modes.Any() ? string.Join(", ", modes) : "None"));
                    break;

                case "6":
                    Console.WriteLine("Frequency chart:");
                    Console.WriteLine(list.GetFrequencyGraph());
                    break;

                case "7":
                    Console.Write("Enter item to check existence: ");
                    var searchItem = Console.ReadLine();
                    if (!string.IsNullOrEmpty(searchItem))
                        Console.WriteLine(list.Contains(searchItem)
                            ? "Item exists in the list." : "Item does not exist.");
                    break;

                case "8":
                    Console.Write("Enter item to remove first occurrence: ");
                    var removeItem = Console.ReadLine();
                    if (!string.IsNullOrEmpty(removeItem))
                        Console.WriteLine(list.Remove(removeItem)
                            ? "First occurrence removed." : "Item not found.");
                    break;

                case "9":
                    Console.Write("Enter item to remove all occurrences: ");
                    var removeAllItem = Console.ReadLine();
                    if (!string.IsNullOrEmpty(removeAllItem))
                    {
                        int count = list.RemoveAll(removeAllItem);
                        Console.WriteLine($"Removed {count} occurrence(s).");
                    }
                    break;

                case "10":
                   list.Clear();
                   Console.WriteLine("All items have been removed. The list is now empty.");
                   break;

                case "0":
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (option != "0")
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }

        } while (option != "0");
    

    static string ShowMenu()
    {
        Console.WriteLine("1. Add item");
        Console.WriteLine("2. Show list forward");
        Console.WriteLine("3. Show list backward");
        Console.WriteLine("4. Sort descending");
        Console.WriteLine("5. Show mode(s)");
        Console.WriteLine("6. Show frequency chart");
        Console.WriteLine("7. Check existence");
        Console.WriteLine("8. Remove first occurrence");
        Console.WriteLine("9. Remove all occurrences");
        Console.WriteLine("10. Clear list");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
        return Console.ReadLine() ?? "0";
    }

