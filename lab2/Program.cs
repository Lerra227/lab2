

BadPupil Nikita = new BadPupil();
GoodPupil Danil = new GoodPupil();
ExcellentPupil Lera = new ExcellentPupil();

ClassRoom B10 = new ClassRoom(Nikita, Danil, Lera);
Console.WriteLine("Lera:");
Lera.Study();
Lera.Write();
Lera.Read();
Lera.Relax();
Console.WriteLine("Danil:");
Danil.Study();
Danil.Write();
Danil.Read();
Danil.Relax();
Console.WriteLine("Nikita:");
Nikita.Study();
Nikita.Write();
Nikita.Read();
Nikita.Relax();

Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////");

Car Toyota = new Car(3000000, 250, 2012);
Ship Pobeda = new Ship(1238792429, 80, 2020, 2567, "Arhangelsk" );
Plane MC21 = new Plane(1234560998, 350, 2021, 2000, 200);

Console.WriteLine("Toyota:");
Toyota.print();
Console.WriteLine("/////////////////////////////");
Console.WriteLine("Pobeda Ship:");
Pobeda.print();
Console.WriteLine("/////////////////////////////");
Console.WriteLine("Plane MC21:");
MC21.print();

Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////");
Console.WriteLine("Введите ключ доступа:");
DocumentWorker.Main(Console.ReadLine()); 



public class ClassRoom
{
    List<Pupil> pupil = new List<Pupil>(4);
    public ClassRoom (params Pupil[] list)
    {
        if(list.Length == 1) { Console.Write("Unacceptable number of pupil. Expected 2,3,4. "); return; }
        for (int i = 0; i < list.Length; i++ ) pupil.Add(list[i]);
    }

}

public class Pupil
{
    public string quality;
    public virtual void Study() 
    {
        Console.WriteLine("Studing is " + quality);
    }
    public virtual void Read()
    {
        Console.WriteLine("Reading is " + quality);
    }
    public virtual void Write() 
    {
        Console.WriteLine("Writing is " + quality);
    }
    public virtual void Relax() 
    {
        Console.WriteLine("Relaxing is " + quality );
    }
}

public class ExcellentPupil: Pupil
{
    public void Study()
    {
        quality = "excellent";
        base.Study();
    }
    public void Read()
    {
        quality = "excellent";
        base.Read();
    }
    public void Write()
    {
        quality = "excellent";
        base.Write();
    }
    public void Relax()
    {
        quality = "excellent";
        base.Relax();
    }
}

public class GoodPupil: Pupil
{
    public void Study()
    {
        quality = "good";
        base.Study();
    }
    public void Read()
    {
        quality = "good";
        base.Read();
    }
    public void Write()
    {
        quality = "good";
        base.Write();
    }
    public void Relax()
    {
        quality = "good";
        base.Relax();
    }
}

public class BadPupil : Pupil
{
    public void Study()
    {
        quality = "bad(";
        base.Study();
    }
    public void Read()
    {
        quality = "bad(";
        base.Read();

    }
    public void Write()
    {
        quality = "bad(";
        base.Write();
    }
    public void Relax()
    {
        quality = "bad(";
        base.Relax();
    }
}


public class Vehicle
{
    public int price;
    public double speed;
    public int year;
   public Vehicle(int price, double speed, int year)
    {
        this.price = price;
        this.speed = speed;
        this.year = year;
    }
    public virtual void print()
    {
        Console.WriteLine("Price = " + this.price + "\nSpeed = " + this.speed + "km/h" + "\nYear: " + this.year);
    }
}

public class Plane: Vehicle
{
    public int height;
    public int NPassengers;
    public Plane(int price, double speed, int year, int height, int nPassengers) : base(price, speed, year)
    {
        this.height = height;
        NPassengers = nPassengers;
    }

    public void print() 
    { 
        base.print();
        Console.WriteLine("Height = " + this.height + "m" + "\nNumber of passengers = " + this.NPassengers);
    }
}

public class Car: Vehicle
{
    public Car(int price, double speed, int year): base(price, speed, year) {}

}

public class Ship: Vehicle
{
    public int NPassengers;
    public string HPort;

    public Ship(int price, double speed, int year, int NPassengers, string HPort): base(price, speed, year)
    {
        this.HPort = HPort;
        this.NPassengers = NPassengers;
    }
    public void print()
    {
        base.print();
        Console.WriteLine("Number of passengers = " + this.NPassengers + "\nHome port: " + this.HPort);
    }

}


public class DocumentWorker
{
    public virtual void OpenDocument()
    {
        Console.WriteLine("Документ открыт");
    }
    public virtual void EditDocument() {
        Console.WriteLine("Редактирование документа доступно в версии Pro");
    }

    public virtual void SaveDocument()
    {
        Console.WriteLine("Сохранение документа доступно в версии Pro");
    }
    public static void Main(string args)
    {
        int key = Convert.ToInt32(args);
            DocumentWorker worker = new DocumentWorker();
        
        if (args.Length == 0) 
        {
           
            Console.WriteLine("Доступна бесплатная версия");
        }
        else if (key % 3 == 2 || key % 3 == 1)
        {
            worker = new ProDocumentWorker();
            Console.WriteLine("Доступна версия Pro");
            
        }
        else if (key % 3 == 0)
        {
            worker = new ExpertDocumentWorker();
            Console.WriteLine("Доступна версия Expert");
            
        }
            worker.OpenDocument();
            worker.EditDocument();
            worker.SaveDocument();

    }
} 


public class ProDocumentWorker: DocumentWorker
{
    public void EditDocument()
    {
        Console.WriteLine("Документ отредактирован");
    }
    public void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert");
    }
}

public class ExpertDocumentWorker: ProDocumentWorker
{
    public void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в новом формате");
    }
}