using Game.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.Renderer
{
    public class MerlegDisplay : FrameworkElement
    {
        IMerlegModel model;
        Size area;
        static Random r;
        public int[] corrects { get; set; }


        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IMerlegModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();

        }

        public Brush AntBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "Level1_ant.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        //public Brush KettesTeglaBrush
        //{
        //    get
        //    {
        //        return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "2.png"), UriKind.RelativeOrAbsolute)));
        //    }
        //}
        //public Brush HarmasTeglaBrush
        //{
        //    get
        //    {
        //        return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "3.png"), UriKind.RelativeOrAbsolute)));
        //    }
        //}
        //public Brush NegyesTeglaBrush
        //{
        //    get
        //    {
        //        return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "4.png"), UriKind.RelativeOrAbsolute)));
        //    }
        //}



        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (area.Width > 0 && area.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(AntBrush, null, new Rect(0, 0, area.Width, area.Height));
                model = new MerlegLogic();


                //r = new Random();

            }
        }
    }
}
