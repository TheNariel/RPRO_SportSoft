using RPRO_SportSoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class AdditionClasses
    {
    }
}

public class CourtListP
{
   
    public IEnumerable<RPRO_SportSoft.Court> list;
    public String sportName;
    public int sportId;
    public CourtListP(int s, String sT, IEnumerable<RPRO_SportSoft.Court> l)
    {
        this.sportName = sT;
        this.list = l;
        this.sportId = s;
    }
}
public class ReservationFormated
{
    public DateTime date;
    public int courtId;
    public int price;
    public String time;
    public String email;
    public String ids;
    public ReservationFormated(DateTime d, int cId, int price, String time,String ids,String email)
    {
        this.date = d;
        this.courtId = cId;
        this.price = price;
        this.time = time;
        this.ids = ids;
        this.email = email;
    }
}
public static class F
{
    private static int flag;

    public static int Mflag
    {
        get { return flag; }
        set { flag = value; }
    }

}
public class CrateCurtGain
{
    public String name;
    public int count;
    public double gain;
    public CrateCurtGain(String name, int count, double gain)
    {
        this.name = name;
        this.count = count;
        this.gain = gain;
    }
}
public class CratePriceLists
{
    public String date;
    public String description;
    public int price;
    public CratePriceLists(DateTime date,String description, int price)
    {
        this.date = date.ToString("dd.MM.yyyy");
        this.description = description;
        this.price = price;
    }
}
public class ReservationByDay
{
    public ushort[][] allDays = new ushort[7][];
    private ushort[] mon = new ushort[48];
    private ushort[] tue = new ushort[48];
    private ushort[] wed = new ushort[48];
    private ushort[] thu = new ushort[48];
    private ushort[] fri = new ushort[48];
    private ushort[] sat = new ushort[48];
    private ushort[] sun = new ushort[48];
    public ReservationByDay()
    {
        allDays[0] = mon;
        allDays[1] = tue;
        allDays[2] = wed;
        allDays[3] = thu;
        allDays[4] = fri;
        allDays[5] = sat;
        allDays[6] = sun;
    }
    public void addReserv(Reservation r)
    {
        switch (r.Date.DayOfWeek.ToString())
        {
            case "Monday":
                this.allDays[0][r.Time_Id] += 1;
                break;
            case "Tuesday":
                this.allDays[1][r.Time_Id] += 1;
                break;
            case "Wednesday":
                this.allDays[2][r.Time_Id] += 1;
                break;
            case "Thursday":
                this.allDays[3][r.Time_Id] += 1;
                break;
            case "Friday":
                this.allDays[4][r.Time_Id] += 1;
                break;
            case "Saturday":
                this.allDays[5][r.Time_Id] += 1;
                break;
            case "Sunday":
                this.allDays[6][r.Time_Id] += 1;
                break;
        }
    }
}
public class Intervals
{
    public List<String> listString;
    public Intervals()
    {
        this.listString = new List<string>();
        listString.Add("0:30");
        listString.Add("1:00");
        listString.Add("1:30");
        listString.Add("2:00");
        listString.Add("2:30");
        listString.Add("3:00");
        listString.Add("3:30");
        listString.Add("4:00");
        listString.Add("4:30");
        listString.Add("5:00");
        listString.Add("5:30");
        listString.Add("6:00");
        listString.Add("6:30");
        listString.Add("7:00");
        listString.Add("7:30");
        listString.Add("8:00");
        listString.Add("8:30");
        listString.Add("9:00");
        listString.Add("9:30");
        listString.Add("10:00");
        listString.Add("10:30");
        listString.Add("11:00");
        listString.Add("11:30");
        listString.Add("12:00");
    }
}