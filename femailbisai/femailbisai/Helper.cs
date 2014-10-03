using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace femailbisai
{
   public class Helper
    {
       public static void ShowDetailpic(Image obj)
       {
           CustomMessageBox imgmessgaebox = new CustomMessageBox();
           ScrollViewer imgscroll = new ScrollViewer();
           imgscroll.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
           imgscroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
           Image contetnimg = new Image();
           //  contetnimg.Source = new BitmapImage(new Uri( (obj.DataContext as PBBBSAction).Content.ThumbImageUrl,UriKind.RelativeOrAbsolute));
           contetnimg.Source = obj.Source;
           imgscroll.Content = contetnimg;
           imgmessgaebox.Content = imgscroll;
           imgmessgaebox.IsFullScreen = true;
           imgmessgaebox.Background = new SolidColorBrush(Colors.Transparent);
           imgmessgaebox.Show();
       }
    }
}
