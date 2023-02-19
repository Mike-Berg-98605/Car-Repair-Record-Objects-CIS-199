/*
 * Grading Id: R9223
 * CIS 199-01
 * Due 4/18/2021
 * Program 4
 * This program create a class of repair record objects 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_4
{
    class Repair // this class hold the data and output method
    {
        static void Main()
        {
            RepairRecord[] carArray = new RepairRecord[6];  //creates the array for the repair record data to be stored
            carArray[0] = new RepairRecord(41050, 2011, "Honda Civic", "C981245839", 15, "Bobby", false); // each array has ints and string that correspond to the constructor in the RepairRecord class
            carArray[1] = new RepairRecord(45555, 2001, "Nat Geo", "C0923483982", 27, "Billy Bob", false);
            carArray[2] = new RepairRecord(89436, 1999, "Hummer", "C098293839", 99, "Kermit The Frog Singing about Rainbows", false);
            carArray[3] = new RepairRecord(999999, 1905, "Ford Focus", "D984325694", 10, "Larry The Cable Guy", false);
            carArray[4] = new RepairRecord(40222, 2010, "Barbie Dream Car", "A187946538", 20, "Ken", true);
            carArray[5] = new RepairRecord(20221, 2019, "I spent 8 hours on this", "Program 4 ", 7, "It was a doozie", true);

      
            WriteLine("UNALTERED DATA ARRAY >>> \n" +
                "=========================");
            WriteLine();
            //for (int x = 0; x < carArray.Length; ++x) { } //outputs all the arrays and with the unaltered data
            
            OutPutRepairRecords(carArray); // calls the method with car array argument
            

            carArray[0].MakeModel = "Hummer"; // these are the changes made to the original array
            carArray[1].MakeModel = "Natural Geo"; // these changes are made AFTER the original array's output
            carArray[2].ModelYear = 1901;
            carArray[3].ServiceLocationZip = 55555;
            carArray[4].TechnicianName = "Dave Chappelle";
            carArray[5].AppointmentLength = 10;

            WriteLine("ALTERED DATA ARRAY >>>\n" +
                      "======================");
            WriteLine();
            //for (int x = 0; x < carArray.Length; ++x) { } //outputs all the arrays with altered data
            
            OutPutRepairRecords(carArray); //call the method again
            
            
        }
        public static void OutPutRepairRecords(RepairRecord[] orders) //this is the method, with car representing the variable corresponding to the order of the constructor
        {
            foreach(RepairRecord order in orders)
            {
                WriteLine(order.ToString());
            }

            /*
            WriteLine($"Service Location Zip Code: {car.ServiceLocationZip}");
            WriteLine($"Year: {car.ModelYear}");
            WriteLine($"Make and Model: {car.MakeModel}");
            WriteLine($"Serial Number: {car.SerialNumber}");
            WriteLine($"Appointment Length: {car.AppointmentLength}");
            WriteLine($"Appointment Hours: {car.AppointmentHours}");
            WriteLine($"Technician Name: {car.TechnicianName}");
            WriteLine($"Warranty Coverage?: {car.WarrantyCoverage}");
            WriteLine($"Calculate Cost Output: {car.CostOuput}");
            WriteLine();
            WriteLine(); 
            */
        }       
    } 
    
    
    class RepairRecord : Repair// this class holds the constructor and properties and validates info
    {
        public RepairRecord(int zip, int year, string make, string serial, int appL, string tech, bool warr) // constructor set up the order that info is provided into the class
        {
            ServiceLocationZip = zip; //each input value corresponds to the assigned property
            ModelYear = year;
            MakeModel = make;
            SerialNumber = serial;
            AppointmentLength = appL;
            TechnicianName = tech;
            WarrantyCoverage = warr;
        }

        public override string ToString()
        {
            string objectString = $"Zip Code: {ServiceLocationZip}\n" +
                $"Year: {ModelYear}\n" +
                $"Make and Model: {MakeModel}\n" +
                $"Serial Number: {SerialNumber}\n" +
                $"Appointment Length: {AppointmentLength} \n" +
                $"Appointment Hours: {AppointmentHours} \n" +
                $"Technician Name: {TechnicianName} \n" +
                $"Warranty Coverage?: {WarrantyCoverage} \n" +
                $"Calculate Cost Output: {CostOuput} \n";
            return objectString;
        }

        private int serviceLocationZip, modelYear, appointmentLength; // these are the variable that hold corresponding data in the properties
        private string makeModel, serialNumber, technicianName;
        private bool warrantyCoverage;
        private double costOutput, appointmentHours;       

        public int ServiceLocationZip // zip code
        {
            get { return serviceLocationZip; }
            set
            {
                const int MIN_ZIP = 00000, MAX_ZIP = 99999, DEFAULT_ZIP = 40204; // validates zip code for an acceptable or default value
                if ((value >= MIN_ZIP) && (value <= MAX_ZIP))
                    serviceLocationZip = value;
                else
                    serviceLocationZip = DEFAULT_ZIP;
            }
        }
        public int ModelYear // year car was made
        {
            get { return modelYear; }
            set { modelYear = value; }
        }
         public string MakeModel //make of care
        {
            get {return makeModel;}
            set
            {
                const string DEFAULT_M_M = "Unknown Make/Model"; //validates makemodel and returns default value if specifications not met
                if (String.IsNullOrEmpty(value))
                    makeModel = DEFAULT_M_M;
                else
                    makeModel = value;
            }
        }
        public string SerialNumber //cars serial number
        {
            get { return serialNumber;}
            set
            {
                const int SERIAL_LENGTH = 10; const string DEFAULT_SERIAL_N = "A000000000"; //sets values to validate serial number
                if (value.Length == SERIAL_LENGTH)
                    serialNumber = value;
                else
                    serialNumber = DEFAULT_SERIAL_N;
            }
        }
        public string TechnicianName //who worked on care
        {
            get { return technicianName; }
            set
            {
                const string DEFAULT_TECH_NAME = "John Smith"; // validates tech name
                if (String.IsNullOrWhiteSpace(value))
                    technicianName = DEFAULT_TECH_NAME;
                else
                    technicianName = value;
            }
        }
        public int AppointmentLength // length of appointment
        {
            get { return appointmentLength; }
            set
            {
                const int MIN_APP = 15, MAX_APP = 180, DEFAULT_APP = 30; // validates appointment length values
                if ((value >= MIN_APP) && (value <= MAX_APP))
                    appointmentLength = value;
                else
                    appointmentLength = DEFAULT_APP;
                HourLength(); // method for determining fraction of an hour
            }
        }
        public double AppointmentHours //holds the fraction of an hour value
        {
            get {return appointmentHours;}
        }
        public bool WarrantyCoverage // warranty coverage
        {
            get {return warrantyCoverage;}
            set
            {
                warrantyCoverage = value;
                CalcCost(); // method that determines cost based on if there is a warranty or not
            }
        }
        public double CostOuput // holds cost value
        {
            get { return costOutput;}

        }
        public double CalcCost() // method that determines cost
        {
            const double W_WARR_FEE = 20.00, FLAT_FEE = 25.00, HOURLY_RATE = 1.50;
            if (warrantyCoverage == true) // if there is warranty
                costOutput = W_WARR_FEE;
            else
                costOutput = FLAT_FEE + HOURLY_RATE * AppointmentLength; // if there is not warranty
            return costOutput; // returns cost
        }
        public double HourLength() //method for calculating hour fraction
        {
            double MINS_IN_HOUR = 60;
            appointmentHours = appointmentLength / MINS_IN_HOUR;
            return appointmentHours; //return fraction
        }
               
    }
}
