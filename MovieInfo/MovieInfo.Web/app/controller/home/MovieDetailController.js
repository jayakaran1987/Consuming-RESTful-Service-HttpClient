// Controller

app.controller('MovieDetailController', function ($scope, $http) {

    // kendo datasource for Auto Complete
    $scope.productsDataSource = {
        serverFiltering: true,
        transport: {
            read: {
                url: "Home/SearchMovieDetails",
                dataType: "json",
            },
            parameterMap: function () {
                return { searchTerm: $("#autocomplete").data("kendoAutoComplete").value() };
            }
        }
    };

    // Search button clicked
    // List View datasource will refersed
    $scope.search = function () {
        $scope.source.read();
    };

    // Image Click - detail movie View
    $scope.DetailView = function () {
        $http({
            method: 'POST',
            url: 'Home/GetMovieById',
            data: { ImdbId: this.dataItem.ImdbId}
        }).then(function successCallback(response) {
            // this callback will be called asynchronously
            // when the response is available
            $scope.movie = response.data;
            $scope.detailWindow.open();
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
            alert("Something went wrong");
        });
        
        
    };

    // List View datasource
    $scope.source = new kendo.data.DataSource({
        transport: {
            read: {
                url: "Home/SearchMovieDetailsForListView",
                dataType: "json",
            },
            parameterMap: function () {
                return { searchTerm: $("#autocomplete").data("kendoAutoComplete").value() };
            }
        },
        pageSize: 16
    });

    // Kendo Autocomplete
    $scope.customOptions = {
        dataSource: $scope.productsDataSource,
        dataTextField: "Title",
        minLength: 2,
        // using  templates:
        template: '<div class="row"><div class="col-sm-2"><span class="k-state-default"> # if (data.Poster == "N/A") { # <img height="100" width="100" src=\Content/images/no_image.jpg alt=\"\" /># } else { #<img height="100" width="100" src=\"#:data.Poster#" alt=\"\" /># } #</span></div><div class="col-sm-6"><span class="k-state-default"><h4>#: data.Title #</h4><p>#: data.Type #</p></span></div></div>',
    };
});