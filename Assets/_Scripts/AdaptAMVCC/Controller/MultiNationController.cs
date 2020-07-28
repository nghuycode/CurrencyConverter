using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiNationController : Controller<GameplayApp>
{
    public void AddCountryToList(CountryModel src) {
        var multiNationModel = app.model.MultiNationModel;
        var multiNationView = app.view.MultiNationView;
        multiNationModel.ListCountryModel.Add(src);
        multiNationView.AddNewTextViewToContent(src);
        multiNationView.OnListTextViewUpdated(multiNationModel.ListCountryModel);
    }
}
