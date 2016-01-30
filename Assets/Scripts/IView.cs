using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public interface IView {

    //Get the root
    RectTransform GetRoot();

    //Switch to the next view
    void ChangeView(IView nextView);

}
