using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class TestPanel : PanelBase {

    public Button Button;
    public override void Init(params object[] _args)
    {
         args = _args;
         CurViewPath="Prefabs/MyUI/View/TestPanel";
         layer = PanelLayer.Panel;
    }
    public override void InitComponent()
    {
        Button = curView.transform.Find("Button_Button").GetComponent<Button>();
        Button.onClick.AddListener(ButtonOnClick);
        CustomComponent();
    }
    //——————————上面部分自动生成，每次生成都会替换掉，不要手写东西——————————
                                                                                                
    //——————————以下为手写部分，初始化补充方法为CustomComponent()———————————
    //@EndMark@
    public void ButtonOnClick()
    {
        
    }
        
    public void CustomComponent()
    {
        
    }
        
    public override void OnShow()
    {
        base.OnShow(); 
    }
        
    public override void Update()
    {
        
    }
        
    public override void OnHide()
    {
        base.OnHide();    
    }
        
    public override void OnClose()
    {
         base.OnClose();   
    }
}
