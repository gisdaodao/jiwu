using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace jiewu
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 将 listbox 控件的数据上下文设置为示例数据
            DataContext = App.ViewModel;
            jiewu.MediaOpened += jiewu_MediaOpened;
            jiewu.MediaFailed += jiewu_MediaFailed;
            jiewu.Source = new Uri("http://k.youku.com/player/getFlvPath/sid/7407696443988122cc477_00/st/flv/fileid/03000201004B3A6448D4E8002A7D49A3B7D432-3995-8003-BDA3-56F231B6D7C1?K=6d037192416c82252411e676&ctype=12&ev=1&oip=2095617680&token=5709&ep=dSaUHU%2BEUMoE5irXgD8bZX%2BxcHAIXP4J9h%2BFg9JjALsgOuvOnzrVz%2Bm0O%2FdCFvtodVYCGZry2deTbkMWYfNKoG0Q106oOvqSioHg5ahVspIDZ2swBsqktVSbRDD4",UriKind.Absolute);
        }

        void jiewu_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void jiewu_MediaOpened(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        // 为 ViewModel 项加载数据
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }
    }
}