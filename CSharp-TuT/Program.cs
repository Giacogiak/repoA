using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharp_TuT
{
    class Program
    {
     
        private static void Main(string[] args)
        {
            //Console.WriteLine("bucio de culo");
            ////test on args passed into the main fuction
            //for (int i = 0; i < args.Length; i++)
            //{
            //    Console.WriteLine("Args {0}:{1}", i, args[i]);
            //}
            ////printing out the path
            //string[] myArgs = Environment.GetCommandLineArgs();
            //Console.WriteLine(string.Join(", ", myArgs));
            ////integers longs and other variables
            //Console.WriteLine("Biggest int: {0}", int.MaxValue);
            //Console.WriteLine("Lowest int: {0}", int.MinValue);
            //Console.WriteLine("Biggest long: {0}", long.MaxValue);
            //Console.WriteLine("Lowest long: {0}", long.MinValue);
            //// decimals doubles and floats .. 
            //double dblBigNum = 3.5500000000000;
            //Console.WriteLine("Biggest DBL: {0}", Double.MaxValue.ToString("#"));
            //// from string to other types with fuction called "parse"
            //bool boolFromStr = bool.Parse("true");
            //int intFromStr = int.Parse("100");
            //double dblFromString = double.Parse("1.546876");
            //// working with Dates and Time

            //DateTime awesomeDate = new DateTime(1986, 5, 6);
            //Console.WriteLine("Day of Week:{0}", awesomeDate.DayOfWeek);

            //awesomeDate = awesomeDate.AddDays(11);
            //awesomeDate = awesomeDate.AddMonths(-2);
            //awesomeDate = awesomeDate.AddYears(-2);
            //Console.WriteLine("New Date : {0}", awesomeDate.Date);

            //TimeSpan lunchTime = new TimeSpan(12, 30, 0);
            //lunchTime = lunchTime.Subtract(new TimeSpan(0, 15, 0));
            //lunchTime = lunchTime.Add(new TimeSpan(1, 0, 0));
            //Console.WriteLine("New Time : {0}", lunchTime.ToString());



            var item = new item();

            item.SetIdentifier();

            Console.WriteLine("item identifier : " + item.identifier);
            Console.WriteLine("////////////////////////////////// " );
            item.PrintIndividualHashes();

            Console.WriteLine("////////////////////////////////// ");

            var hash = item.GetHashCode();
            Console.WriteLine("item hash : " + hash);
            
            Console.ReadLine();
        }
        //hello world with input
        private static void SayHello()
        {
            String name = "";
            Console.Write("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("Ciaone {0} !!!", name);

        }


      


    }


    public class item
    {
        string mode = "TrimLine";
        bool driven = false;
        int partId = 0;
        int[] values = new int[] { 12, 5, 80, 4 };

        public string identifier;
        public void SetIdentifier()
        {
            mode = partId + "_" + driven + "_" + mode;
            
            foreach (int id in values)
                mode =  mode + "_" + id;
            identifier = mode;
        }
        public override int GetHashCode()
        {
            var identifier = partId + "_" + driven + "_" + mode;

            foreach (int id in values)
                identifier = identifier + "_" + id;

            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ identifier.GetHashCode();        
                return hash;
            }          
        }

        public void PrintIndividualHashes()
        {

            Console.WriteLine("mode : {0} ", mode.GetHashCode());
            Console.WriteLine("driven : {0} ", driven.GetHashCode());
            Console.WriteLine("partId : {0} ", partId.GetHashCode());
            foreach (int id in values)
                Console.WriteLine("vert idd : {0} ", id.GetHashCode());
        }
    }

    public static class Datas
    {
        static string[] csv = {

  "name,birthday_day,birthday_month,birthday_year,house_type,house_address_street,house_address_city,house_address_state,house_occupants",
  "Lily Haywood,27,3,1995,Igloo,768 Pocket Walk,Honolulu,HI,7",
  "Stan Marsh,19,10,1987,Treehouse,2001 Bonanza Street,South Park,CO,2"};

    }

    public class Row
    {
        public string name;
        public Bday biday;
        public House hous;
        public int occupants;
        public Row() { }
       
    }
    public class Bday
    {
        public Bday() { }
        public int day;
        public int month;
        public int year;
    }
    public class House
    {
        public House() { }
        string type;
        public Adress adre;
    }
    public class Adress
    {
        public Adress() { }
        public string road;
        public string city;
        public string state;
    }

    class Order
    {
    int user; // the user that creates the order instance
 
    //Patient    
    public string patientID;
    public string gender;
    public int age;

        public Order(string pid, string gen, int a)
        {
            patientID = pid;
            gender = gen;
            age = a;
            //user should be assigned 
        }

        //Category
        public ProductCategory orderCategory;
    public BodyPart bodypart;
    public LimbSide limbSide;
    public bool mirror;
    public char[] limbSegments;
       
     /// Filtering products for selection
        
     Product selectedProd;

    /// add scan /pictures
    /// 

    ////Model
    public ModelingSource modChoice;

        //Series of complementary info about modeling

        public bool clientReviewModel;
        public bool withClosingSys;
        public float globalOffset;
         
    ////Print
    public Manufacturer manufacturer;

    ///Deliverable
    
    public Technologies tech; //to pick among selectedProd.technologies
     
    public DigitalFormat format;

    public Material material; //to pick among selectedProd.materials.Where(x => x.technology == tech) 

        public string shippingAddress;
        public string invoiceAddress;
        public string date;
    }

    

     class Product 
    {
     public ProductCategory category;
     public char[] segmentsIN;
     public char[] segmentsOUT;
     public ProductCode prodCode;  //it is the inheriting class name
     public int[] modelingSources;
     public ProductStatus prodStatus;
     public AlveoliType alvType;
     public int[] technologies;
     public Material[]materials;
    
    }

    enum ProductCategory { Orthosis, Prosthetics, Implants, Other}
    enum BodyPart      {UpperLimb,LowerLimb,Head,Torso,NA}
    enum LimbSide      {Left,Right,NA}
    enum ProductFamily {A,H,W,Q,B,C,K,L}
    enum ProductCode   {A1,A2,A3,A4,A5,A6,H1,H2,W1,W2,Q1,Q2,Q3,Q4,Q5,Q6,Q7,Q8,B1,B2,B6,B8,K1,K2,C1,C2,C3,D1,D2}
    enum ProductStatus {Valid,Prototype,Other}
    enum ModelingSource{Designer,freeForma,fastForma,autoForma,Other}
    enum AlveoliType   {None,Small,Large}
    enum Manufacturer  {Spentys,Local,Other}
    enum Technologies  {FDM,DLP,SLS}
    enum DigitalFormat {None,STL,gCode}
    enum Designer      {Ali,Davide,Jose,Begonya}
    
    class Material
    {
     public string name;
     public string chemicaldefinition;
     public int technology;
    }
   
}
