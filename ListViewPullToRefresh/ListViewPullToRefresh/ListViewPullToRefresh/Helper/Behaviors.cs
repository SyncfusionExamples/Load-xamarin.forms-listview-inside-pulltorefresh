using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewSample 
{
    #region PullToRefreshBehavior

    public class SfListViewPullToRefreshBehavior : Behavior<ContentPage>
    {
        #region Fields

        private ListViewPullToRefreshViewModel pulltoRefreshViewModel;
        private SfListView ListView;
        private SfPullToRefresh pullToRefresh = null;
        private Picker picker;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(ContentPage bindable)
        {

            
            pullToRefresh = bindable.FindByName<SfPullToRefresh>("pullToRefresh");
            ListView = bindable.FindByName<SfListView>("listView");

            pulltoRefreshViewModel = new ListViewPullToRefreshViewModel();
            pulltoRefreshViewModel.Navigation = bindable.Navigation;

            ListView.BindingContext = pulltoRefreshViewModel;
            ListView.ItemsSource = pulltoRefreshViewModel.BlogsInfo;
            
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;

            picker = bindable.FindByName<Picker>("transitionTypePicker");
            picker.Items.Add("SlideOnTop");
            picker.Items.Add("Push");
            picker.SelectedIndex = 1;
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
            picker.SelectedIndexChanged -= Picker_SelectedIndexChanged;
            base.OnDetachingFrom(bindable);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == 0)
            {
                pullToRefresh.RefreshContentThreshold = 0;
                pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
            else
            {
                pullToRefresh.RefreshContentThreshold = 50;
                pullToRefresh.TransitionMode = TransitionType.Push;
            }
        }

        #endregion

        #region Private Methods
        private async void PullToRefresh_Refreshing(object sender, EventArgs args)
        {
            pullToRefresh.IsRefreshing = true;
            await Task.Delay(2000);
            var blogsTitleCount = pulltoRefreshViewModel.BlogsTitle.Count() - 1;

            if ((pulltoRefreshViewModel.BlogsInfo.Count - 1) == blogsTitleCount)
            {
                pullToRefresh.IsRefreshing = false;
                return;
            }

            var blogsCategoryCount = pulltoRefreshViewModel.BlogsCategory.Count() - 1;
            var blogsAuthorCount = pulltoRefreshViewModel.BlogsAuthers.Count() - 1;
            var blogsReadMoreCount = pulltoRefreshViewModel.BlogsReadMoreInfo.Count() - 1;

            for (int i = 0; i < 3; i++)
            {
                var blogsCount = pulltoRefreshViewModel.BlogsInfo.Count;
                var item = new ListViewBlogsInfo()
                {
                    BlogTitle = pulltoRefreshViewModel.BlogsTitle[blogsTitleCount - blogsCount],
                    BlogAuthor = pulltoRefreshViewModel.BlogsAuthers[blogsAuthorCount - blogsCount],
                    BlogCategory = pulltoRefreshViewModel.BlogsCategory[blogsCategoryCount - blogsCount],
                    ReadMoreContent = pulltoRefreshViewModel.BlogsReadMoreInfo[blogsReadMoreCount - blogsCount],
                    BlogAuthorIcon = ImageSource.FromResource("ListViewSample.Images.BlogAuthor.png"),
                    BlogCategoryIcon = ImageSource.FromResource("ListViewSample.Images.BlogCategory.png"),
                    BlogFacebookIcon = ImageSource.FromResource("ListViewSample.Images.Blog_Facebook.png"),
                    BlogTwitterIcon = ImageSource.FromResource("ListViewSample.Images.Blog_Twitter.png"),
                    BlogGooglePlusIcon = ImageSource.FromResource("ListViewSample.Images.Blog_Google Plus.png"),
                    BlogLinkedInIcon = ImageSource.FromResource("ListViewSample.Images.Blog_LinkedIn.png"),
                };
                pulltoRefreshViewModel.BlogsInfo.Insert(0, item);
            }
            pullToRefresh.IsRefreshing = false;
        }

        #endregion
    }

    #endregion
}