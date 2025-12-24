using System;

namespace BridgeLabz_Training.Review.BusSeatAllocation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bus Seat Allocation App\n");

            while (true)
            {
                Console.WriteLine("Enter the seat you want to book: ");
                string? input = Console.ReadLine();

                SeatAllocation seat = new SeatAllocation(seat);

                while (true)
                {
                    Console.WriteLine("\n MENU");
                    Console.WriteLine("1. Book Seat");
                    Console.WriteLine("2. Check");
                    Console.WriteLine("3. Change");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");

                    string? choiceInput = Console.ReadLine();

                    if (!int.TryParse(choiceInput, out int choice))
                    {
                        Console.WriteLine(" Invalid choice. Enter a number between 1 and 4.");
                        continue;
                    }

                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter the seat you want to book: ");

                                int bookedSeat = seat();
                                seat.Book(bookedSeat);

                                Console.WriteLine("Seat booking successful.");
                                break;

                            case 2:
                                Console.Write("Check the confirmation seat: ");

                                int checkSeatConfirmation = seat();

                                seat.Check(checkSeatConfirmation);

                                Console.WriteLine(" Seat Confirmed");
                                break;

                            case 3:
                                Console.WriteLine("To Change the bus");
                                break;

                            case 4:
                                Console.WriteLine("Thank you for using Bus Seat Allocation Application!");
                                return;

                            default:
                                Console.WriteLine("Invalid choice. Select between 1 and 4.");
                                break;
                        }
                    }

                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($" Error: {ex.Message}");
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($" Unexpected Error: {ex.Message}");
                    }
                }
            }
        }
    }
}