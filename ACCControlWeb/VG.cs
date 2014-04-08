using System;
using SQL;
using FIREBIRD;

public sealed class VG
{
    private static volatile VG instance;
    private static object syncRoot = new Object();

    private string[] dias = new string[] { "Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab" };

    public string[] Dias
    {
        get
        {
            return dias;
        }
    }

    private VG() { }

    public MySQL sql;
    public Fb fb;

    public static VG Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new VG();
                    }
                }
            }

            return instance;
        }
    }
}
