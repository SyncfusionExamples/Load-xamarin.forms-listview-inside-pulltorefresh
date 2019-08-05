# ListView inside PullToRefresh

The SfListView supports refreshing the data in view when performing the pull-to-refresh action at runtime by loading it directly into the [SfPullToRefresh.PullableContent](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfPullToRefresh.XForms~Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh~PullableContent.html) of the [SfPullToRefresh](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfPullToRefresh.XForms~Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh.html).

```
<ContentPage xmlns:pulltoRefresh="clr-namespace:Syncfusion.SfPullToRefresh.XForms;assembly=Syncfusion.SfPullToRefresh.XForms"
             xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms" >
 <pullToRefresh:SfPullToRefresh x:Name="pullToRefresh"
                               ProgressBackgroundColor="#428BCA" RefreshContentHeight="50" 
                               RefreshContentWidth="50" TransitionMode="Push" IsRefreshing="False">
  <pullToRefresh:SfPullToRefresh.PullableContent>
    <syncfusion:SfListView x:Name="listView" ItemSize="120"
                           SelectionMode="None">
    </syncfusion:SfListView>
  </pullToRefresh:SfPullToRefresh.PullableContent>
 </pullToRefresh:SfPullToRefresh>
</ContentPage>
```
## Loading data when refreshing

To refresh the data in view at runtime, use the [SfPullToRefresh.Refreshing](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfPullToRefresh.XForms~Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh~Refreshing_EV.html) event. The `Refreshing` event gets triggered once the progress bar meets 100 %. The data can be added into the underlying collection, and the data gets updated in view once the `Refreshing` event gets completed.

```
pullToRefresh.Refreshing += PullToRefresh_Refreshing;

private async void PullToRefresh_Refreshing(object sender, EventArgs args)
{
   pullToRefresh.IsRefreshing = true;
   await Task.Delay(2000);
 
   for (int i = 0; i < 3; i++)
   {
      var blogsCount = pullToRefreshViewModel.BlogsInfo.Count;
      var item = new ListViewBlogsInfo()
      {
         BlogTitle = pullToRefreshViewModel.BlogsTitle[blogsTitleCount - blogsCount],
         BlogAuthor = pullToRefreshViewModel.BlogsAuthors[blogsAuthorCount - blogsCount],
         BlogCategory = pullToRefreshViewModel.BlogsCategory[blogsCategoryCount - blogsCount],
         ReadMoreContent = pullToRefreshViewModel.BlogsReadMoreInfo[blogsReadMoreCount - blogsCount],
      };
      pullToRefreshViewModel.BlogsInfo.Insert(0, item);
   }
   pullToRefresh.IsRefreshing = false;
}
```

To know more about pulltorefresh, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/pull-to-refresh)