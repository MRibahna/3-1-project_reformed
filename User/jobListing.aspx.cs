﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class jobListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
    // Setting default image if their is no image for any job.

    protected string GetImageUrl(Object url)
    {
        string url1 = "";
        if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
        {
            url1 = "~/Images/No_image.png";
        }
        else
        {
            url1 = string.Format("~/ {0}", url);
        }
        return ResolveUrl(url1);
    }

    // Getting RelativeDate for given date like -- '1 month ago'

    public static string RelativeDate(DateTime theDate)

    {

        Dictionary<long, string> thresholds = new Dictionary<long, string>();

        int minute = 60;

        int hour = 60 * minute;

        int day = 24 * hour;

        thresholds.Add(60, "{0} seconds ago");

        thresholds.Add(minute * 2, "a minute ago");

        thresholds.Add(45 * minute, "{0} minutes ago");

        thresholds.Add(120 * minute, "an hour ago");

        thresholds.Add(day, "{0} hours ago");

        thresholds.Add(day * 2, "yesterday");

        thresholds.Add(day * 30, "{0} days ago");

        thresholds.Add(day * 365, "{0} months ago");

        thresholds.Add(long.MaxValue, "{0} years ago");

        long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;

        foreach (long threshold in thresholds.Keys)

        {

            if (since < threshold)

            {

                TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));

                return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());

            }

        }

        return "";

    }




}