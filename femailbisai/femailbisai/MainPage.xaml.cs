using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Xml.Linq;
using System.Collections;
using GoogleAds;
using Microsoft.Phone.Tasks;

namespace femailbisai
{
    public partial class MainPage : PhoneApplicationPage
    {
        WebClient Pclient = new WebClient();
        List<string> urls = new List<string>();
        List<Info> items = new List<Info>();
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            // 将 listbox 控件的数据上下文设置为示例数据
            interstitialAd = new InterstitialAd("ca-app-pub-1598808565430684/3997460859");
            // NOTE: You can edit the event handler to do something custom here. Once the
            // interstitial is received it can be shown whenever you want.
            interstitialAd.ReceivedAd += OnAdReceived;
            AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = false;
            interstitialAd.LoadAd(adRequest);
            Pclient.OpenReadCompleted += Pclient_OpenReadCompleted;
            Pclient.OpenReadAsync(new Uri("https://raw.githubusercontent.com/gisdaodao/jiwu/master/jiewu/femalebisai.xml", UriKind.Absolute));          
        }
        private InterstitialAd interstitialAd;
        private void OnAdReceived(object sender, AdEventArgs e)
        {
            Random P = new Random();
            int I = P.Next(1, 10);
            if (I > 5)
            {
                interstitialAd.ShowAd();
            }
        }
        // 为 ViewModel 项加载数据
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
          
        }

        void Pclient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if(e.Error==null)
            {
                Stream stream = e.Result;
                XElement p = XElement.Load(stream);
            
                XName xname = XName.Get("url");
                IEnumerable<XElement> nodes= p.Descendants(xname).ToList<XElement>();
                foreach(var a in nodes)
                {
                    urls.Add(a.Value);
                }
                Deployment.Current.Dispatcher.BeginInvoke(() => { lstbox.ItemsSource = urls; });
                XName xitemname = XName.Get("item");
                IEnumerable<XElement> itemnodes = p.Descendants(xitemname).ToList<XElement>();
                foreach (var b in itemnodes)
                {

                    items.Add(new Info() { text = b.FirstAttribute.Value, info = b.LastAttribute.Value });
                }
                Deployment.Current.Dispatcher.BeginInvoke(() => { longlistbox.ItemsSource = items; });
            }
        
        }

        private void joinAppbar_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

      
    }
    public class Info
    {
        public string text{get;set;}
          public string info{get;set;}
    }
}