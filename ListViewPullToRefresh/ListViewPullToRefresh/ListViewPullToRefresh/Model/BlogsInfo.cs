using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewSample 
{
    public class ListViewBlogsInfo : INotifyPropertyChanged
    {
        #region Fields

        private string blogTitle;
        private string blogCategory;
        private string blogAuthor;
        private ImageSource categoryIcon;
        private ImageSource autherIcon;
        private ImageSource blogFacebookIcon;
        private ImageSource blogTwitterIcon;
        private ImageSource blogGooglePlusIcon;
        private ImageSource blogLinkedInIcon;
        private string readMoreContent;

        #endregion

        #region Constructor

        public ListViewBlogsInfo()
        {

        }

        #endregion

        #region Properties

        public string BlogTitle
        {
            get { return blogTitle; }
            set
            {
                blogTitle = value;
                OnPropertyChanged("BlogTitle");
            }
        }

        public string BlogCategory
        {
            get { return blogCategory; }
            set
            {
                blogCategory = value;
                OnPropertyChanged("BlogCategory");
            }
        }

        public string BlogAuthor
        {
            get { return blogAuthor; }
            set
            {
                blogAuthor = value;
                OnPropertyChanged("BlogAuthor");
            }
        }

        public ImageSource BlogAuthorIcon
        {
            get { return autherIcon; }
            set
            {
                autherIcon = value;
                OnPropertyChanged("BlogAuthorIcon");
            }
        }

        public ImageSource BlogCategoryIcon
        {
            get { return categoryIcon; }
            set
            {
                categoryIcon = value;
                OnPropertyChanged("BlogCategoryIcon");
            }
        }

        public ImageSource BlogFacebookIcon
        {
            get { return blogFacebookIcon; }
            set
            {
                blogFacebookIcon = value;
                OnPropertyChanged("BlogFacebookIcon");
            }
        }

        public ImageSource BlogTwitterIcon
        {
            get { return blogTwitterIcon; }
            set
            {
                blogTwitterIcon = value;
                OnPropertyChanged("BlogTwitterIcon");
            }
        }

        public ImageSource BlogGooglePlusIcon
        {
            get { return blogGooglePlusIcon; }
            set
            {
                blogGooglePlusIcon = value;
                OnPropertyChanged("BlogGooglePlusIcon");
            }
        }

        public ImageSource BlogLinkedInIcon
        {
            get { return blogLinkedInIcon; }
            set
            {
                blogLinkedInIcon = value;
                OnPropertyChanged("BlogLinkedInIcon");
            }
        }

        public string ReadMoreContent
        {
            get { return readMoreContent; }
            set
            {
                readMoreContent = value;
                OnPropertyChanged("ReadMoreContent");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
