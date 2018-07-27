<%@ Application Language="C#" %>

<script RunAt="server">
    bool timerEnabled = false;
    static System.Timers.Timer timer = new System.Timers.Timer();
    static public string TextFromAsax = "";

    void Application_Start(object sender, EventArgs e)
    {

        timer.Interval = 600000;
            //CalculateInterval();
        timer.Elapsed += tm_Tick;
        TextFromAsax = "timer started";
    }

    private static double CalculateInterval()
    {
        return (DateTime.Now.AddDays(1).Date.AddHours(8.5) - DateTime.Now).TotalMilliseconds;
    }

    void tm_Tick(object sender, EventArgs e)
    {
        //go to db and check 
        CheckHW();
    }

    public static void CheckHW()
    {
        HomeWork HW = new HomeWork();
        Dictionary<string,string> USers= HW.GetPupilIdWhiceDidntMakeHWYet();

        List<Users> userList = new List<Users>();

        foreach (var item in USers)
        {
            Users u = new Users();
            u.UserID1 = item.Key.ToString();
            u.RegId = item.Value.ToString();
            userList.Add(u);
        }

        string message = "טרם ביצעת שיעורי בית ב" +userList[0].UserID1 +", הם למחר חבל ):";
        string title = "תזכורת";

        myPushNot pushNot = new myPushNot(message, title, "1", 7, "default");
        pushNot.RunPushNotification(userList, pushNot);
    }

    public static void StartTimer()
    {
        timer.Enabled = true;
    }

    public static void EndTimer()
    {
        timer.Enabled = false;
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
