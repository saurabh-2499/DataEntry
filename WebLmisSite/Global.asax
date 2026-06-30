<%@ Application Language="C#" %>

<script runat="server">

   
    
    
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
     

    }
    void Application_End(object sender, EventArgs e)
    {
       
    }
    void Application_Error(object sender, EventArgs e)
    {
        
        // Code that runs when an unhandled error occurs
    }
    void Session_Start(object sender, EventArgs e)
    {
        //Application.Lock();
        //    Application["OnlineVisitors"] = (int)Application["OnlineVisitors"] + 1;

        //    Application.UnLock();
    }
    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends.
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer
        // or SQLServer, the event is not raised.
        //if (Convert.ToInt32(Application["OnlineVisitors"]) > 0)
        //{
        //    Application.Lock();
        //    Application["OnlineVisitors"] = (int)Application["OnlineVisitors"] - 1;
        //    Application.UnLock();
        //}
        
      
    }

   
       
</script>
