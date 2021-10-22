﻿using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{
    public class RadioButtonEx : System.Windows.Forms.RadioButton
    {
        public osf.RadioButton M_Object;
    }

    public class RadioButton : ButtonBase
    {
        public string CheckChanged;
        public ClRadioButton dll_obj;
        private RadioButtonEx m_RadioButton;

        public RadioButton()
        {
            M_RadioButton = new RadioButtonEx();
            M_RadioButton.M_Object = this;
            base.M_ButtonBase = M_RadioButton;
            CheckChanged = "";
        }

        public RadioButton(osf.RadioButton p1)
        {
            M_RadioButton = p1.M_RadioButton;
            M_RadioButton.M_Object = this;
            base.M_ButtonBase = M_RadioButton;
            CheckChanged = "";
        }

        public RadioButton(System.Windows.Forms.RadioButton p1)
        {
            M_RadioButton = (RadioButtonEx)p1;
            M_RadioButton.M_Object = this;
            base.M_ButtonBase = M_RadioButton;
            CheckChanged = "";
        }

        public int Appearance
        {
            get { return (int)M_RadioButton.Appearance; }
            set { M_RadioButton.Appearance = (System.Windows.Forms.Appearance)value; }
        }

        public bool AutoCheck
        {
            get { return M_RadioButton.AutoCheck; }
            set { M_RadioButton.AutoCheck = value; }
        }

        public int CheckAlign
        {
            get { return (int)M_RadioButton.CheckAlign; }
            set { M_RadioButton.CheckAlign = (System.Drawing.ContentAlignment)value; }
        }

        public bool Checked
        {
            get { return M_RadioButton.Checked; }
            set { M_RadioButton.Checked = value; }
        }

        public RadioButtonEx M_RadioButton
        {
            get { return m_RadioButton; }
            set
            {
                m_RadioButton = value;
                m_RadioButton.CheckedChanged += M_RadioButton_CheckedChanged;
            }
        }

        private void M_RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckChanged.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = CheckChanged;
                EventArgs1.Sender = this;
                dynamic event1 = ((dynamic)this).dll_obj.CheckChanged;
                if (event1.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    EventArgs1.Parameter = ((osf.ClDictionaryEntry)event1).Key;
                }
                else if (event1.GetType() == typeof(ScriptEngine.HostedScript.Library.DelegateAction))
                {
                    EventArgs1.Parameter = (ScriptEngine.HostedScript.Library.DelegateAction)event1;
                }
                else
                {
                    EventArgs1.Parameter = null;
                }
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }
    }

    [ContextClass ("КлПереключатель", "ClRadioButton")]
    public class ClRadioButton : AutoContext<ClRadioButton>
    {
        private IValue _CheckChanged;
        private IValue _Click;
        private IValue _ControlAdded;
        private IValue _ControlRemoved;
        private IValue _DoubleClick;
        private IValue _Enter;
        private IValue _KeyDown;
        private IValue _KeyPress;
        private IValue _KeyUp;
        private IValue _Leave;
        private IValue _LocationChanged;
        private IValue _LostFocus;
        private IValue _MouseDown;
        private IValue _MouseEnter;
        private IValue _MouseHover;
        private IValue _MouseLeave;
        private IValue _MouseMove;
        private IValue _MouseUp;
        private IValue _Move;
        private IValue _Paint;
        private IValue _SizeChanged;
        private IValue _TextChanged;
        private ClColor backColor;
        private ClRectangle bounds;
        private ClRectangle clientRectangle;
        private ClControlCollection controls;
        private ClColor foreColor;
        private ClCollection tag = new ClCollection();

        public ClRadioButton()
        {
            RadioButton RadioButton1 = new RadioButton();
            RadioButton1.dll_obj = this;
            Base_obj = RadioButton1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
		
        public ClRadioButton(RadioButton p1)
        {
            RadioButton RadioButton1 = p1;
            RadioButton1.dll_obj = this;
            Base_obj = RadioButton1;
            bounds = new ClRectangle(Base_obj.Bounds);
            clientRectangle = new ClRectangle(Base_obj.ClientRectangle);
            foreColor = new ClColor(Base_obj.ForeColor);
            backColor = new ClColor(Base_obj.BackColor);
            controls = new ClControlCollection(Base_obj.Controls);
        }
        
        public RadioButton Base_obj;
        
        [ContextProperty("АвтоПометка", "AutoCheck")]
        public bool AutoCheck
        {
            get { return Base_obj.AutoCheck; }
            set { Base_obj.AutoCheck = value; }
        }

        [ContextProperty("ВерсияПродукта", "ProductVersion")]
        public string ProductVersion
        {
            get { return Base_obj.ProductVersion; }
        }

        [ContextProperty("Верх", "Top")]
        public int Top
        {
            get { return Base_obj.Top; }
            set { Base_obj.Top = value; }
        }

        [ContextProperty("ВыравниваниеИзображения", "ImageAlign")]
        public int ImageAlign
        {
            get { return (int)Base_obj.ImageAlign; }
            set { Base_obj.ImageAlign = value; }
        }

        [ContextProperty("ВыравниваниеПометки", "CheckAlign")]
        public int CheckAlign
        {
            get { return (int)Base_obj.CheckAlign; }
            set { Base_obj.CheckAlign = value; }
        }

        [ContextProperty("ВыравниваниеТекста", "TextAlign")]
        public int TextAlign
        {
            get { return (int)Base_obj.TextAlign; }
            set { Base_obj.TextAlign = value; }
        }

        [ContextProperty("Высота", "Height")]
        public int Height
        {
            get { return Base_obj.Height; }
            set { Base_obj.Height = value; }
        }

        [ContextProperty("ВысотаШрифта", "FontHeight")]
        public int FontHeight
        {
            get { return Convert.ToInt32(Base_obj.FontHeight); }
        }
        
        [ContextProperty("Границы", "Bounds")]
        public ClRectangle Bounds
        {
            get { return bounds; }
            set 
            {
                bounds = value;
                Base_obj.Bounds = value.Base_obj;
            }
        }

        [ContextProperty("ДвойнаяБуферизация", "DoubleBuffered")]
        public bool DoubleBuffered
        {
            get { return Base_obj.DoubleBuffered; }
            set { Base_obj.DoubleBuffered = value; }
        }

        [ContextProperty("ДвойноеНажатие", "DoubleClick")]
        public IValue DoubleClick
        {
            get
            {
                if (Base_obj.DoubleClick.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _DoubleClick;
                }
                else if (Base_obj.DoubleClick.Contains("osf.ClDictionaryEntry"))
                {
                    return _DoubleClick;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.DoubleClick);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _DoubleClick = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.DoubleClick = "ScriptEngine.HostedScript.Library.DelegateAction" + "DoubleClick";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _DoubleClick = value;
                    Base_obj.DoubleClick = "osf.ClDictionaryEntry" + "DoubleClick";
                }
                else
                {
                    Base_obj.DoubleClick = value.AsString();
                }
            }
        }
        
        [ContextProperty("Доступность", "Enabled")]
        public bool Enabled
        {
            get { return Base_obj.Enabled; }
            set { Base_obj.Enabled = value; }
        }

        [ContextProperty("ЖирныйШрифт", "FontBold")]
        public bool FontBold
        {
            get { return Base_obj.FontBold; }
            set { Base_obj.FontBold = value; }
        }

        [ContextProperty("Захват", "Capture")]
        public bool Capture
        {
            get { return Base_obj.Capture; }
            set { Base_obj.Capture = value; }
        }

        [ContextProperty("Изображение", "Image")]
        public ClBitmap Image
        {
            get { return (ClBitmap)OneScriptForms.RevertObj(Base_obj.Image); }
            set
            {
                Base_obj.Image = value.Base_obj;
                Base_obj.Image.dll_obj = value;
            }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
            set { Base_obj.Name = value; }
        }

        [ContextProperty("ИмяПродукта", "ProductName")]
        public string ProductName
        {
            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
        }
        
        [ContextProperty("ИмяШрифта", "FontName")]
        public string FontName
        {
            get { return Base_obj.FontName; }
            set { Base_obj.FontName = value; }
        }

        [ContextProperty("ИндексИзображения", "ImageIndex")]
        public int ImageIndex
        {
            get { return Base_obj.ImageIndex; }
            set { Base_obj.ImageIndex = value; }
        }

        [ContextProperty("ИспользоватьКурсорОжидания", "UseWaitCursor")]
        public bool UseWaitCursor
        {
            get { return Base_obj.UseWaitCursor; }
            set { Base_obj.UseWaitCursor = value; }
        }

        [ContextProperty("КлавишаВверх", "KeyUp")]
        public IValue KeyUp
        {
            get
            {
                if (Base_obj.KeyUp.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _KeyUp;
                }
                else if (Base_obj.KeyUp.Contains("osf.ClDictionaryEntry"))
                {
                    return _KeyUp;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.KeyUp);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _KeyUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyUp = "ScriptEngine.HostedScript.Library.DelegateAction" + "KeyUp";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _KeyUp = value;
                    Base_obj.KeyUp = "osf.ClDictionaryEntry" + "KeyUp";
                }
                else
                {
                    Base_obj.KeyUp = value.AsString();
                }
            }
        }
        
        [ContextProperty("КлавишаВниз", "KeyDown")]
        public IValue KeyDown
        {
            get
            {
                if (Base_obj.KeyDown.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _KeyDown;
                }
                else if (Base_obj.KeyDown.Contains("osf.ClDictionaryEntry"))
                {
                    return _KeyDown;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.KeyDown);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _KeyDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyDown = "ScriptEngine.HostedScript.Library.DelegateAction" + "KeyDown";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _KeyDown = value;
                    Base_obj.KeyDown = "osf.ClDictionaryEntry" + "KeyDown";
                }
                else
                {
                    Base_obj.KeyDown = value.AsString();
                }
            }
        }
        
        [ContextProperty("КлавишаНажата", "KeyPress")]
        public IValue KeyPress
        {
            get
            {
                if (Base_obj.KeyPress.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _KeyPress;
                }
                else if (Base_obj.KeyPress.Contains("osf.ClDictionaryEntry"))
                {
                    return _KeyPress;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.KeyPress);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _KeyPress = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.KeyPress = "ScriptEngine.HostedScript.Library.DelegateAction" + "KeyPress";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _KeyPress = value;
                    Base_obj.KeyPress = "osf.ClDictionaryEntry" + "KeyPress";
                }
                else
                {
                    Base_obj.KeyPress = value.AsString();
                }
            }
        }
        
        [ContextProperty("КлиентВысота", "ClientHeight")]
        public int ClientHeight
        {
            get { return Base_obj.ClientHeight; }
            set { Base_obj.ClientHeight = value; }
        }

        [ContextProperty("КлиентПрямоугольник", "ClientRectangle")]
        public ClRectangle ClientRectangle
        {
            get { return clientRectangle; }
        }

        [ContextProperty("КлиентРазмер", "ClientSize")]
        public ClSize ClientSize
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.ClientSize); }
            set { Base_obj.ClientSize = value.Base_obj; }
        }

        [ContextProperty("КлиентШирина", "ClientWidth")]
        public int ClientWidth
        {
            get { return Base_obj.ClientWidth; }
            set { Base_obj.ClientWidth = value; }
        }

        [ContextProperty("КнопкиМыши", "MouseButtons")]
        public int MouseButtons
        {
            get { return (int)Base_obj.MouseButtons; }
        }

        [ContextProperty("КонтекстноеМеню", "ContextMenu")]
        public ClContextMenu ContextMenu
        {
            get { return (ClContextMenu)OneScriptForms.RevertObj(Base_obj.ContextMenu); }
            set { Base_obj.ContextMenu = value.Base_obj; }
        }

        [ContextProperty("Курсор", "Cursor")]
        public ClCursor Cursor
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Cursor); }
            set { Base_obj.Cursor = value.Base_obj; }
        }

        [ContextProperty("Лево", "Left")]
        public int Left
        {
            get { return Base_obj.Left; }
            set { Base_obj.Left = value; }
        }

        [ContextProperty("Метка", "Tag")]
        public ClCollection Tag
        {
            get { return tag; }
        }
        
        [ContextProperty("МышьНадЭлементом", "MouseEnter")]
        public IValue MouseEnter
        {
            get
            {
                if (Base_obj.MouseEnter.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseEnter;
                }
                else if (Base_obj.MouseEnter.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseEnter;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseEnter);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseEnter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseEnter = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseEnter";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseEnter = value;
                    Base_obj.MouseEnter = "osf.ClDictionaryEntry" + "MouseEnter";
                }
                else
                {
                    Base_obj.MouseEnter = value.AsString();
                }
            }
        }
        
        [ContextProperty("МышьПокинулаЭлемент", "MouseLeave")]
        public IValue MouseLeave
        {
            get
            {
                if (Base_obj.MouseLeave.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseLeave;
                }
                else if (Base_obj.MouseLeave.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseLeave;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseLeave);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseLeave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseLeave = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseLeave";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseLeave = value;
                    Base_obj.MouseLeave = "osf.ClDictionaryEntry" + "MouseLeave";
                }
                else
                {
                    Base_obj.MouseLeave = value.AsString();
                }
            }
        }
        
        [ContextProperty("Нажатие", "Click")]
        public IValue Click
        {
            get
            {
                if (Base_obj.Click.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Click;
                }
                else if (Base_obj.Click.Contains("osf.ClDictionaryEntry"))
                {
                    return _Click;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Click);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Click = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Click = "ScriptEngine.HostedScript.Library.DelegateAction" + "Click";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Click = value;
                    Base_obj.Click = "osf.ClDictionaryEntry" + "Click";
                }
                else
                {
                    Base_obj.Click = value.AsString();
                }
            }
        }
        
        [ContextProperty("Низ", "Bottom")]
        public int Bottom
        {
            get { return Base_obj.Bottom; }
        }

        [ContextProperty("ОсновнойЦвет", "ForeColor")]
        public ClColor ForeColor
        {
            get { return foreColor; }
            set 
            {
                foreColor = value;
                Base_obj.ForeColor = value.Base_obj;
            }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("Оформление", "Appearance")]
        public int Appearance
        {
            get { return (int)Base_obj.Appearance; }
            set { Base_obj.Appearance = value; }
        }

        [ContextProperty("ПлоскийСтиль", "FlatStyle")]
        public int FlatStyle
        {
            get { return (int)Base_obj.FlatStyle; }
            set { Base_obj.FlatStyle = value; }
        }

        [ContextProperty("ПозицияМыши", "MousePosition")]
        public ClPoint MousePosition
        {
            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
        }
        
        [ContextProperty("Положение", "Location")]
        public ClPoint Location
        {
            get { return (ClPoint)OneScriptForms.RevertObj(Base_obj.Location); }
            set { Base_obj.Location = value.Base_obj; }
        }

        [ContextProperty("ПоложениеИзменено", "LocationChanged")]
        public IValue LocationChanged
        {
            get
            {
                if (Base_obj.LocationChanged.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _LocationChanged;
                }
                else if (Base_obj.LocationChanged.Contains("osf.ClDictionaryEntry"))
                {
                    return _LocationChanged;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.LocationChanged);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _LocationChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LocationChanged = "ScriptEngine.HostedScript.Library.DelegateAction" + "LocationChanged";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _LocationChanged = value;
                    Base_obj.LocationChanged = "osf.ClDictionaryEntry" + "LocationChanged";
                }
                else
                {
                    Base_obj.LocationChanged = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПометкаИзменена", "CheckChanged")]
        public IValue CheckChanged
        {
            get
            {
                if (Base_obj.CheckChanged.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _CheckChanged;
                }
                else if (Base_obj.CheckChanged.Contains("osf.ClDictionaryEntry"))
                {
                    return _CheckChanged;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.CheckChanged);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _CheckChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.CheckChanged = "ScriptEngine.HostedScript.Library.DelegateAction" + "CheckChanged";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _CheckChanged = value;
                    Base_obj.CheckChanged = "osf.ClDictionaryEntry" + "CheckChanged";
                }
                else
                {
                    Base_obj.CheckChanged = value.AsString();
                }
            }
        }
        
        [ContextProperty("Помечен", "Checked")]
        public bool Checked
        {
            get { return Base_obj.Checked; }
            set { Base_obj.Checked = value; }
        }

        [ContextProperty("ПорядокОбхода", "TabIndex")]
        public int TabIndex
        {
            get { return Base_obj.TabIndex; }
            set { Base_obj.TabIndex = value; }
        }

        [ContextProperty("Право", "Right")]
        public int Right
        {
            get { return Base_obj.Right; }
        }

        [ContextProperty("ПриВходе", "Enter")]
        public IValue Enter
        {
            get
            {
                if (Base_obj.Enter.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Enter;
                }
                else if (Base_obj.Enter.Contains("osf.ClDictionaryEntry"))
                {
                    return _Enter;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Enter);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Enter = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Enter = "ScriptEngine.HostedScript.Library.DelegateAction" + "Enter";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Enter = value;
                    Base_obj.Enter = "osf.ClDictionaryEntry" + "Enter";
                }
                else
                {
                    Base_obj.Enter = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриЗадержкеМыши", "MouseHover")]
        public IValue MouseHover
        {
            get
            {
                if (Base_obj.MouseHover.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseHover;
                }
                else if (Base_obj.MouseHover.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseHover;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseHover);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseHover = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseHover = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseHover";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseHover = value;
                    Base_obj.MouseHover = "osf.ClDictionaryEntry" + "MouseHover";
                }
                else
                {
                    Base_obj.MouseHover = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриНажатииКнопкиМыши", "MouseDown")]
        public IValue MouseDown
        {
            get
            {
                if (Base_obj.MouseDown.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseDown;
                }
                else if (Base_obj.MouseDown.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseDown;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseDown);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseDown = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseDown = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseDown";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseDown = value;
                    Base_obj.MouseDown = "osf.ClDictionaryEntry" + "MouseDown";
                }
                else
                {
                    Base_obj.MouseDown = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриОтпусканииМыши", "MouseUp")]
        public IValue MouseUp
        {
            get
            {
                if (Base_obj.MouseUp.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseUp;
                }
                else if (Base_obj.MouseUp.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseUp;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseUp);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseUp = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseUp = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseUp";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseUp = value;
                    Base_obj.MouseUp = "osf.ClDictionaryEntry" + "MouseUp";
                }
                else
                {
                    Base_obj.MouseUp = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПеремещении", "Move")]
        public IValue Move
        {
            get
            {
                if (Base_obj.Move.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Move;
                }
                else if (Base_obj.Move.Contains("osf.ClDictionaryEntry"))
                {
                    return _Move;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Move);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Move = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Move = "ScriptEngine.HostedScript.Library.DelegateAction" + "Move";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Move = value;
                    Base_obj.Move = "osf.ClDictionaryEntry" + "Move";
                }
                else
                {
                    Base_obj.Move = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПеремещенииМыши", "MouseMove")]
        public IValue MouseMove
        {
            get
            {
                if (Base_obj.MouseMove.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _MouseMove;
                }
                else if (Base_obj.MouseMove.Contains("osf.ClDictionaryEntry"))
                {
                    return _MouseMove;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.MouseMove);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _MouseMove = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.MouseMove = "ScriptEngine.HostedScript.Library.DelegateAction" + "MouseMove";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _MouseMove = value;
                    Base_obj.MouseMove = "osf.ClDictionaryEntry" + "MouseMove";
                }
                else
                {
                    Base_obj.MouseMove = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПерерисовке", "Paint")]
        public IValue Paint
        {
            get
            {
                if (Base_obj.Paint.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Paint;
                }
                else if (Base_obj.Paint.Contains("osf.ClDictionaryEntry"))
                {
                    return _Paint;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Paint);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Paint = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Paint = "ScriptEngine.HostedScript.Library.DelegateAction" + "Paint";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Paint = value;
                    Base_obj.Paint = "osf.ClDictionaryEntry" + "Paint";
                }
                else
                {
                    Base_obj.Paint = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриПотереФокуса", "LostFocus")]
        public IValue LostFocus
        {
            get
            {
                if (Base_obj.LostFocus.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _LostFocus;
                }
                else if (Base_obj.LostFocus.Contains("osf.ClDictionaryEntry"))
                {
                    return _LostFocus;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.LostFocus);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _LostFocus = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.LostFocus = "ScriptEngine.HostedScript.Library.DelegateAction" + "LostFocus";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _LostFocus = value;
                    Base_obj.LostFocus = "osf.ClDictionaryEntry" + "LostFocus";
                }
                else
                {
                    Base_obj.LostFocus = value.AsString();
                }
            }
        }
        
        [ContextProperty("ПриУходе", "Leave")]
        public IValue Leave
        {
            get
            {
                if (Base_obj.Leave.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _Leave;
                }
                else if (Base_obj.Leave.Contains("osf.ClDictionaryEntry"))
                {
                    return _Leave;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.Leave);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _Leave = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.Leave = "ScriptEngine.HostedScript.Library.DelegateAction" + "Leave";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _Leave = value;
                    Base_obj.Leave = "osf.ClDictionaryEntry" + "Leave";
                }
                else
                {
                    Base_obj.Leave = value.AsString();
                }
            }
        }
        
        [ContextProperty("Размер", "Size")]
        public ClSize Size
        {
            get { return (ClSize)OneScriptForms.RevertObj(Base_obj.Size); }
            set { Base_obj.Size = value.Base_obj; }
        }

        [ContextProperty("РазмерИзменен", "SizeChanged")]
        public IValue SizeChanged
        {
            get
            {
                if (Base_obj.SizeChanged.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _SizeChanged;
                }
                else if (Base_obj.SizeChanged.Contains("osf.ClDictionaryEntry"))
                {
                    return _SizeChanged;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.SizeChanged);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _SizeChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.SizeChanged = "ScriptEngine.HostedScript.Library.DelegateAction" + "SizeChanged";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _SizeChanged = value;
                    Base_obj.SizeChanged = "osf.ClDictionaryEntry" + "SizeChanged";
                }
                else
                {
                    Base_obj.SizeChanged = value.AsString();
                }
            }
        }
        
        [ContextProperty("РазмерШрифта", "FontSize")]
        public int FontSize
        {
            get { return Convert.ToInt32(Base_obj.FontSize); }
            set { Base_obj.FontSize = value; }
        }
        
        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
        }
        
        [ContextProperty("СписокИзображений", "ImageList")]
        public ClImageList ImageList
        {
            get { return (ClImageList)OneScriptForms.RevertObj(Base_obj.ImageList); }
            set { Base_obj.ImageList = value.Base_obj; }
        }

        [ContextProperty("Стыковка", "Dock")]
        public int Dock
        {
            get { return (int)Base_obj.Dock; }
            set { Base_obj.Dock = value; }
        }

        [ContextProperty("Сфокусирован", "Focused")]
        public bool Focused
        {
            get { return Base_obj.Focused; }
        }

        [ContextProperty("ТабФокус", "TabStop")]
        public bool TabStop
        {
            get { return Base_obj.TabStop; }
            set { Base_obj.TabStop = value; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ТекстИзменен", "TextChanged")]
        public IValue TextChanged
        {
            get
            {
                if (Base_obj.TextChanged.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _TextChanged;
                }
                else if (Base_obj.TextChanged.Contains("osf.ClDictionaryEntry"))
                {
                    return _TextChanged;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.TextChanged);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _TextChanged = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.TextChanged = "ScriptEngine.HostedScript.Library.DelegateAction" + "TextChanged";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _TextChanged = value;
                    Base_obj.TextChanged = "osf.ClDictionaryEntry" + "TextChanged";
                }
                else
                {
                    Base_obj.TextChanged = value.AsString();
                }
            }
        }
        
        [ContextProperty("Тип", "Type")]
        public ClType Type
        {
            get { return new ClType(this); }
        }
        
        [ContextProperty("Фокусируемый", "CanFocus")]
        public bool CanFocus
        {
            get { return Base_obj.CanFocus; }
        }

        [ContextProperty("ФоновоеИзображение", "BackgroundImage")]
        public ClBitmap BackgroundImage
        {
            get { return new ClBitmap(Base_obj.BackgroundImage); }
            set { Base_obj.BackgroundImage = value.Base_obj; }
        }

        [ContextProperty("ЦветФона", "BackColor")]
        public ClColor BackColor
        {
            get { return backColor; }
            set 
            {
                backColor = value;
                Base_obj.BackColor = value.Base_obj;
            }
        }

        [ContextProperty("Ширина", "Width")]
        public int Width
        {
            get { return Base_obj.Width; }
            set { Base_obj.Width = value; }
        }

        [ContextProperty("Шрифт", "Font")]
        public ClFont Font
        {
            get { return (ClFont)OneScriptForms.RevertObj(Base_obj.Font); }
            set 
            {
                Base_obj.Font = value.Base_obj; 
                Base_obj.Font.dll_obj = value;
            }
        }

        [ContextProperty("ЭлементВерхнегоУровня", "TopLevelControl")]
        public IValue TopLevelControl
        {
            get { return OneScriptForms.RevertObj(Base_obj.TopLevelControl); }
        }
        
        [ContextProperty("ЭлементДобавлен", "ControlAdded")]
        public IValue ControlAdded
        {
            get
            {
                if (Base_obj.ControlAdded.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _ControlAdded;
                }
                else if (Base_obj.ControlAdded.Contains("osf.ClDictionaryEntry"))
                {
                    return _ControlAdded;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.ControlAdded);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _ControlAdded = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ControlAdded = "ScriptEngine.HostedScript.Library.DelegateAction" + "ControlAdded";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _ControlAdded = value;
                    Base_obj.ControlAdded = "osf.ClDictionaryEntry" + "ControlAdded";
                }
                else
                {
                    Base_obj.ControlAdded = value.AsString();
                }
            }
        }
        
        [ContextProperty("ЭлементУдален", "ControlRemoved")]
        public IValue ControlRemoved
        {
            get
            {
                if (Base_obj.ControlRemoved.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
                {
                    return _ControlRemoved;
                }
                else if (Base_obj.ControlRemoved.Contains("osf.ClDictionaryEntry"))
                {
                    return _ControlRemoved;
                }
                else
                {
                    return ValueFactory.Create((string)Base_obj.ControlRemoved);
                }
            }
            set
            {
                if (value.GetType().ToString() == "ScriptEngine.HostedScript.Library.DelegateAction")
                {
                    _ControlRemoved = (ScriptEngine.HostedScript.Library.DelegateAction)value.AsObject();
                    Base_obj.ControlRemoved = "ScriptEngine.HostedScript.Library.DelegateAction" + "ControlRemoved";
                }
                else if (value.GetType() == typeof(osf.ClDictionaryEntry))
                {
                    _ControlRemoved = value;
                    Base_obj.ControlRemoved = "osf.ClDictionaryEntry" + "ControlRemoved";
                }
                else
                {
                    Base_obj.ControlRemoved = value.AsString();
                }
            }
        }
        
        [ContextProperty("ЭлементыУправления", "Controls")]
        public ClControlCollection Controls
        {
            get { return controls; }
        }

        [ContextProperty("Якорь", "Anchor")]
        public int Anchor
        {
            get { return (int)Base_obj.Anchor; }
            set { Base_obj.Anchor = value; }
        }
        
        [ContextMethod("Актуализировать", "Refresh")]
        public void Refresh()
        {
            Base_obj.Refresh();
        }
					
        [ContextMethod("Аннулировать", "Invalidate")]
        public void Invalidate()
        {
            Base_obj.Invalidate();
        }
					
        [ContextMethod("ВозобновитьРазмещение", "ResumeLayout")]
        public void ResumeLayout(bool p1 = false)
        {
            Base_obj.ResumeLayout(p1);
        }

        [ContextMethod("ВосстановитьФоновоеИзображение", "ResetBackgroundImage")]
        public void ResetBackgroundImage()
        {
            Base_obj.ResetBackgroundImage();
        }
					
        [ContextMethod("Выбрать", "Select")]
        public void Select()
        {
            Base_obj.Select();
        }
					
        [ContextMethod("ВыполнитьРазмещение", "PerformLayout")]
        public void PerformLayout()
        {
            Base_obj.PerformLayout();
        }
					
        [ContextMethod("Выше", "PlaceTop")]
        public void PlaceTop(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top - Base_obj.Height - p2);
        }
        
        [ContextMethod("ДочернийПоКоординатам", "GetChildAtPoint")]
        public IValue GetChildAtPoint(ClPoint p1)
        {
            return ((dynamic)Base_obj.GetChildAtPoint(p1.Base_obj)).dll_obj;
        }
        
        [ContextMethod("ЗавершитьОбновление", "EndUpdate")]
        public void EndUpdate()
        {
            Base_obj.EndUpdate();
        }
					
        [ContextMethod("Левее", "PlaceLeft")]
        public void PlaceLeft(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left - Base_obj.Width - p2, p3.Top);
        }
        
        [ContextMethod("НаЗаднийПлан", "SendToBack")]
        public void SendToBack()
        {
            Base_obj.SendToBack();
        }
					
        [ContextMethod("НайтиФорму", "FindForm")]
        public ClForm FindForm()
        {
            if (Base_obj.FindForm() != null)
            {
                return Base_obj.FindForm().dll_obj;
            }
            return null;
        }
        
        [ContextMethod("НайтиЭлемент", "FindControl")]
        public IValue FindControl(string p1)
        {
            return OneScriptForms.RevertObj(Base_obj.FindControl(p1));
        }
        
        [ContextMethod("НаПереднийПлан", "BringToFront")]
        public void BringToFront()
        {
            Base_obj.BringToFront();
        }
					
        [ContextMethod("НачатьОбновление", "BeginUpdate")]
        public void BeginUpdate()
        {
            Base_obj.BeginUpdate();
        }
					
        [ContextMethod("Ниже", "PlaceBottom")]
        public void PlaceBottom(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Left, p3.Top + p3.Height + p2);
        }
        
        [ContextMethod("Обновить", "Update")]
        public void Update()
        {
            Base_obj.Update();
        }
					
        [ContextMethod("ОбновитьСтили", "UpdateStyles")]
        public void UpdateStyles()
        {
            Base_obj.UpdateStyles();
        }
					
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
					
        [ContextMethod("Показать", "Show")]
        public void Show()
        {
            Base_obj.Show();
        }
					
        [ContextMethod("ПолучитьСтиль", "GetStyle")]
        public bool GetStyle(int p1)
        {
            return Base_obj.GetStyle((System.Windows.Forms.ControlStyles)p1);
        }

        [ContextMethod("Правее", "PlaceRight")]
        public void PlaceRight(IValue p1, int p2)
        {
            dynamic p3 = ((dynamic)p1).Base_obj;
            Base_obj.Location = new Point(p3.Right + p2, p3.Top);
        }
        
        [ContextMethod("ПриостановитьРазмещение", "SuspendLayout")]
        public void SuspendLayout()
        {
            Base_obj.SuspendLayout();
        }
					
        [ContextMethod("Скрыть", "Hide")]
        public void Hide()
        {
            Base_obj.Hide();
        }
					
        [ContextMethod("СледующийЭлемент", "GetNextControl")]
        public IValue GetNextControl(IValue p1, bool p2)
        {
            return Base_obj.GetNextControl(((dynamic)p1).Base_obj, p2).dll_obj;
        }
        
        [ContextMethod("СоздатьГрафику", "CreateGraphics")]
        public ClGraphics CreateGraphics()
        {
            return new ClGraphics(Base_obj.CreateGraphics());
        }
        
        [ContextMethod("СоздатьЭлемент", "CreateControl")]
        public void CreateControl()
        {
            Base_obj.CreateControl();
        }
					
        [ContextMethod("ТочкаНаКлиенте", "PointToClient")]
        public ClPoint PointToClient(ClPoint p1)
        {
            return new ClPoint(Base_obj.PointToClient(p1.Base_obj));
        }

        [ContextMethod("ТочкаНаЭкране", "PointToScreen")]
        public ClPoint PointToScreen(ClPoint p1)
        {
            return new ClPoint(Base_obj.PointToScreen(p1.Base_obj));
        }

        [ContextMethod("УстановитьГраницы", "SetBounds")]
        public void SetBounds(int p1, int p2, int p3, int p4)
        {
            Base_obj.SetBounds(p1, p2, p3, p4);
        }

        [ContextMethod("УстановитьСтиль", "SetStyle")]
        public void SetStyle(int p1, bool p2)
        {
            Base_obj.SetStyle((System.Windows.Forms.ControlStyles)p1, p2);
        }

        [ContextMethod("Фокус", "Focus")]
        public void Focus()
        {
            Base_obj.Focus();
        }
					
        [ContextMethod("Центр", "Center")]
        public void Center()
        {
            Base_obj.Center();
        }
					
        [ContextMethod("ЭлементУправления", "Control")]
        public IValue Control(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.getControl(p1));
        }
        
        [ContextMethod("ЭлементыУправления", "Controls")]
        public IValue Controls2(int p1)
        {
            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
        }
    }
}
