﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;
using System.Runtime.InteropServices;

namespace osf
{
    [ContextClass ("ФормыДляОдноСкрипта", "OneScriptForms")]
    public class OneScriptForms : AutoContext<OneScriptForms>
    {
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)] public static extern int WaitMessage();
        private static ClAnchorStyles cl_AnchorStyles = new ClAnchorStyles();
        private static ClAppearance cl_Appearance = new ClAppearance();
        private static ClBorderStyle cl_BorderStyle = new ClBorderStyle();
        private static ClCharacterCasing cl_CharacterCasing = new ClCharacterCasing();
        private static ClCheckState cl_CheckState = new ClCheckState();
        private static ClCloseReason cl_CloseReason = new ClCloseReason();
        private static ClColorDepth cl_ColorDepth = new ClColorDepth();
        private static ClColumnHeaderStyle cl_ColumnHeaderStyle = new ClColumnHeaderStyle();
        private static ClComboBoxStyle cl_ComboBoxStyle = new ClComboBoxStyle();
        private static ClContentAlignment cl_ContentAlignment = new ClContentAlignment();
        private static ClControlStyles cl_ControlStyles = new ClControlStyles();
        private static ClDataRowState cl_DataRowState = new ClDataRowState();
        private static ClDataType cl_DataType = new ClDataType();
        private static ClDay cl_Day = new ClDay();
        private static ClDialogResult cl_DialogResult = new ClDialogResult();
        private static ClDockStyle cl_DockStyle = new ClDockStyle();
        private static ClDrawMode cl_DrawMode = new ClDrawMode();
        private static ClFlatStyle cl_FlatStyle = new ClFlatStyle();
        private static ClFontStyle cl_FontStyle = new ClFontStyle();
        private static ClFormatDateTimePicker cl_FormatDateTimePicker = new ClFormatDateTimePicker();
        private static ClFormBorderStyle cl_FormBorderStyle = new ClFormBorderStyle();
        private static ClFormStartPosition cl_FormStartPosition = new ClFormStartPosition();
        private static ClFormWindowState cl_FormWindowState = new ClFormWindowState();
        private static ClGridItemType cl_GridItemType = new ClGridItemType();
        private static ClHatchStyle cl_HatchStyle = new ClHatchStyle();
        private static ClHorizontalAlignment cl_HorizontalAlignment = new ClHorizontalAlignment();
        private static ClImageLayout cl_ImageLayout = new ClImageLayout();
        private static ClItemActivation cl_ItemActivation = new ClItemActivation();
        private static ClKeys cl_Keys = new ClKeys();
        private static ClLeftRightAlignment cl_LeftRightAlignment = new ClLeftRightAlignment();
        private static ClLinkLabelLinkBehavior cl_LinkLabelLinkBehavior = new ClLinkLabelLinkBehavior();
        private static ClListViewAlignment cl_ListViewAlignment = new ClListViewAlignment();
        private static ClMenuMerge cl_MenuMerge = new ClMenuMerge();
        private static ClMessageBoxButtons cl_MessageBoxButtons = new ClMessageBoxButtons();
        private static ClMessageBoxIcon cl_MessageBoxIcon = new ClMessageBoxIcon();
        private static ClMouseButtons cl_MouseButtons = new ClMouseButtons();
        private static ClMouseFlags cl_MouseFlags = new ClMouseFlags();
        private static ClNotifyFilters cl_NotifyFilters = new ClNotifyFilters();
        private static ClPictureBoxSizeMode cl_PictureBoxSizeMode = new ClPictureBoxSizeMode();
        private static ClPixelFormat cl_PixelFormat = new ClPixelFormat();
        private static ClProcessWindowStyle cl_ProcessWindowStyle = new ClProcessWindowStyle();
        private static ClPropertySort cl_PropertySort = new ClPropertySort();
        private static ClRichTextBoxFinds cl_RichTextBoxFinds = new ClRichTextBoxFinds();
        private static ClRichTextBoxStreamType cl_RichTextBoxStreamType = new ClRichTextBoxStreamType();
        private static ClScrollBars cl_ScrollBars = new ClScrollBars();
        private static ClScrollEventType cl_ScrollEventType = new ClScrollEventType();
        private static ClScrollOrientation cl_ScrollOrientation = new ClScrollOrientation();
        private static ClSeekOrigin cl_SeekOrigin = new ClSeekOrigin();
        private static ClSelectionMode cl_SelectionMode = new ClSelectionMode();
        private static ClShortcut cl_Shortcut = new ClShortcut();
        private static ClSortOrder cl_SortOrder = new ClSortOrder();
        private static ClSortType cl_SortType = new ClSortType();
        private static ClSounds cl_Sounds = new ClSounds();
        private static ClSpecialFolder cl_SpecialFolder = new ClSpecialFolder();
        private static ClStatusBarPanelAutoSize cl_StatusBarPanelAutoSize = new ClStatusBarPanelAutoSize();
        private static ClStatusBarPanelBorderStyle cl_StatusBarPanelBorderStyle = new ClStatusBarPanelBorderStyle();
        private static ClTabAlignment cl_TabAlignment = new ClTabAlignment();
        private static ClTabAppearance cl_TabAppearance = new ClTabAppearance();
        private static ClTabSizeMode cl_TabSizeMode = new ClTabSizeMode();
        private static ClToolBarAppearance cl_ToolBarAppearance = new ClToolBarAppearance();
        private static ClToolBarButtonStyle cl_ToolBarButtonStyle = new ClToolBarButtonStyle();
        private static ClToolBarTextAlign cl_ToolBarTextAlign = new ClToolBarTextAlign();
        private static ClTreeViewAction cl_TreeViewAction = new ClTreeViewAction();
        private static ClView cl_View = new ClView();
        private static ClWatcherChangeTypes cl_WatcherChangeTypes = new ClWatcherChangeTypes();
        public static IValue Event = null;
        public static System.Collections.ArrayList EventQueue = new System.Collections.ArrayList();
        public static string EventString = "";
        public static ClForm FirstForm = null;
        public static bool goOn = true;
        public static System.Collections.Hashtable hashtable = new Hashtable();
        public static System.Random Random = new Random();
        [DllImport("User32.dll")] static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new OneScriptForms();
        }
        
        [ContextProperty("АргументыСобытия", "EventArgs")]
        public IValue EventArgs
        {
            get { return Event; }
        }
        
        [ContextProperty("ВерсияПродукта", "ProductVersion")]
        public ClVersion ProductVersion
        {
            get { return new ClVersion(Assembly.GetExecutingAssembly().GetName().Version); }
        }
        
        [ContextProperty("ИмяПродукта", "ProductName")]
        public string ProductName
        {
            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
        }
        
        [ContextProperty("Отправитель", "Sender")]
        public IValue Sender
        {
            get { return OneScriptForms.RevertObj(((dynamic)Event).Base_obj.Sender); }
        }
        
        [ContextProperty("Продолжать", "GoOn")]
        public bool GoOn
        {
            get
            {
                PostEventProcessing();
                return goOn;
            }
            set { goOn = value; }
        }
        
        [ContextProperty("Сборка", "Build")]
        public int Build
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.Build; }
        }				

        //ПеречисленияКакСвойства============================================================

        [ContextProperty("АвтоРазмерПанелиСтрокиСостояния", "StatusBarPanelAutoSize")]
        public ClStatusBarPanelAutoSize StatusBarPanelAutoSize
        {
            get { return cl_StatusBarPanelAutoSize; }
        }

        [ContextProperty("АктивацияЭлемента", "ItemActivation")]
        public ClItemActivation ItemActivation
        {
            get { return cl_ItemActivation; }
        }

        [ContextProperty("ВыравниваниеВкладок", "TabAlignment")]
        public ClTabAlignment TabAlignment
        {
            get { return cl_TabAlignment; }
        }

        [ContextProperty("ВыравниваниеВСпискеЭлементов", "ListViewAlignment")]
        public ClListViewAlignment ListViewAlignment
        {
            get { return cl_ListViewAlignment; }
        }

        [ContextProperty("ВыравниваниеСодержимого", "ContentAlignment")]
        public ClContentAlignment ContentAlignment
        {
            get { return cl_ContentAlignment; }
        }

        [ContextProperty("ВыравниваниеТекстаВПанелиИнструментов", "ToolBarTextAlign")]
        public ClToolBarTextAlign ToolBarTextAlign
        {
            get { return cl_ToolBarTextAlign; }
        }

        [ContextProperty("ГлубинаЦвета", "ColorDepth")]
        public ClColorDepth ColorDepth
        {
            get { return cl_ColorDepth; }
        }

        [ContextProperty("ГоризонтальноеВыравнивание", "HorizontalAlignment")]
        public ClHorizontalAlignment HorizontalAlignment
        {
            get { return cl_HorizontalAlignment; }
        }

        [ContextProperty("День", "Day")]
        public ClDay Day
        {
            get { return cl_Day; }
        }

        [ContextProperty("ДеревоДействие", "TreeViewAction")]
        public ClTreeViewAction TreeViewAction
        {
            get { return cl_TreeViewAction; }
        }

        [ContextProperty("Звуки", "Sounds")]
        public ClSounds Sounds
        {
            get { return cl_Sounds; }
        }

        [ContextProperty("ЗначокОкнаСообщений", "MessageBoxIcon")]
        public ClMessageBoxIcon MessageBoxIcon
        {
            get { return cl_MessageBoxIcon; }
        }

        [ContextProperty("Клавиши", "Keys")]
        public ClKeys Keys
        {
            get { return cl_Keys; }
        }

        [ContextProperty("КнопкиМыши", "MouseButtons")]
        public ClMouseButtons MouseButtons
        {
            get { return cl_MouseButtons; }
        }

        [ContextProperty("КнопкиОкнаСообщений", "MessageBoxButtons")]
        public ClMessageBoxButtons MessageBoxButtons
        {
            get { return cl_MessageBoxButtons; }
        }

        [ContextProperty("ЛевоеПравоеВыравнивание", "LeftRightAlignment")]
        public ClLeftRightAlignment LeftRightAlignment
        {
            get { return cl_LeftRightAlignment; }
        }

        [ContextProperty("НаблюдательИзмененияВида", "WatcherChangeTypes")]
        public ClWatcherChangeTypes WatcherChangeTypes
        {
            get { return cl_WatcherChangeTypes; }
        }

        [ContextProperty("НачальноеПоложениеФормы", "FormStartPosition")]
        public ClFormStartPosition FormStartPosition
        {
            get { return cl_FormStartPosition; }
        }

        [ContextProperty("ОриентацияПолосы", "ScrollOrientation")]
        public ClScrollOrientation ScrollOrientation
        {
            get { return cl_ScrollOrientation; }
        }

        [ContextProperty("ОсобаяПапка", "SpecialFolder")]
        public ClSpecialFolder SpecialFolder
        {
            get { return cl_SpecialFolder; }
        }

        [ContextProperty("Оформление", "Appearance")]
        public ClAppearance Appearance
        {
            get { return cl_Appearance; }
        }

        [ContextProperty("ОформлениеВкладок", "TabAppearance")]
        public ClTabAppearance TabAppearance
        {
            get { return cl_TabAppearance; }
        }

        [ContextProperty("ОформлениеПанелиИнструментов", "ToolBarAppearance")]
        public ClToolBarAppearance ToolBarAppearance
        {
            get { return cl_ToolBarAppearance; }
        }

        [ContextProperty("ПлоскийСтиль", "FlatStyle")]
        public ClFlatStyle FlatStyle
        {
            get { return cl_FlatStyle; }
        }

        [ContextProperty("ПоведениеСсылки", "LinkLabelLinkBehavior")]
        public ClLinkLabelLinkBehavior LinkLabelLinkBehavior
        {
            get { return cl_LinkLabelLinkBehavior; }
        }

        [ContextProperty("ПозицияПоиска", "SeekOrigin")]
        public ClSeekOrigin SeekOrigin
        {
            get { return cl_SeekOrigin; }
        }

        [ContextProperty("ПолосыПрокрутки", "ScrollBars")]
        public ClScrollBars ScrollBars
        {
            get { return cl_ScrollBars; }
        }

        [ContextProperty("ПорядокСортировки", "SortOrder")]
        public ClSortOrder SortOrder
        {
            get { return cl_SortOrder; }
        }

        [ContextProperty("ПричинаЗакрытия", "CloseReason")]
        public ClCloseReason CloseReason
        {
            get { return cl_CloseReason; }
        }

        [ContextProperty("РазмещениеИзображения", "ImageLayout")]
        public ClImageLayout ImageLayout
        {
            get { return cl_ImageLayout; }
        }

        [ContextProperty("РегистрСимволов", "CharacterCasing")]
        public ClCharacterCasing CharacterCasing
        {
            get { return cl_CharacterCasing; }
        }

        [ContextProperty("РежимВыбора", "SelectionMode")]
        public ClSelectionMode SelectionMode
        {
            get { return cl_SelectionMode; }
        }

        [ContextProperty("РежимОтображения", "View")]
        public ClView View
        {
            get { return cl_View; }
        }

        [ContextProperty("РежимРазмераВкладок", "TabSizeMode")]
        public ClTabSizeMode TabSizeMode
        {
            get { return cl_TabSizeMode; }
        }

        [ContextProperty("РежимРазмераПоляКартинки", "PictureBoxSizeMode")]
        public ClPictureBoxSizeMode PictureBoxSizeMode
        {
            get { return cl_PictureBoxSizeMode; }
        }

        [ContextProperty("РежимРисования", "DrawMode")]
        public ClDrawMode DrawMode
        {
            get { return cl_DrawMode; }
        }

        [ContextProperty("РезультатДиалога", "DialogResult")]
        public ClDialogResult DialogResult
        {
            get { return cl_DialogResult; }
        }

        [ContextProperty("СлияниеМеню", "MenuMerge")]
        public ClMenuMerge MenuMerge
        {
            get { return cl_MenuMerge; }
        }

        [ContextProperty("СортировкаСвойств", "PropertySort")]
        public ClPropertySort PropertySort
        {
            get { return cl_PropertySort; }
        }

        [ContextProperty("СостояниеОкнаФормы", "FormWindowState")]
        public ClFormWindowState FormWindowState
        {
            get { return cl_FormWindowState; }
        }

        [ContextProperty("СостояниеСтрокиДанных", "DataRowState")]
        public ClDataRowState DataRowState
        {
            get { return cl_DataRowState; }
        }

        [ContextProperty("СостояниеФлажка", "CheckState")]
        public ClCheckState CheckState
        {
            get { return cl_CheckState; }
        }

        [ContextProperty("СочетаниеКлавиш", "Shortcut")]
        public ClShortcut Shortcut
        {
            get { return cl_Shortcut; }
        }

        [ContextProperty("СтилиПривязки", "AnchorStyles")]
        public ClAnchorStyles AnchorStyles
        {
            get { return cl_AnchorStyles; }
        }

        [ContextProperty("СтильГраницы", "BorderStyle")]
        public ClBorderStyle BorderStyle
        {
            get { return cl_BorderStyle; }
        }

        [ContextProperty("СтильГраницыПанелиСтрокиСостояния", "StatusBarPanelBorderStyle")]
        public ClStatusBarPanelBorderStyle StatusBarPanelBorderStyle
        {
            get { return cl_StatusBarPanelBorderStyle; }
        }

        [ContextProperty("СтильГраницыФормы", "FormBorderStyle")]
        public ClFormBorderStyle FormBorderStyle
        {
            get { return cl_FormBorderStyle; }
        }

        [ContextProperty("СтильЗаголовкаКолонки", "ColumnHeaderStyle")]
        public ClColumnHeaderStyle ColumnHeaderStyle
        {
            get { return cl_ColumnHeaderStyle; }
        }

        [ContextProperty("СтильКнопокПанелиИнструментов", "ToolBarButtonStyle")]
        public ClToolBarButtonStyle ToolBarButtonStyle
        {
            get { return cl_ToolBarButtonStyle; }
        }

        [ContextProperty("СтильОкнаПроцесса", "ProcessWindowStyle")]
        public ClProcessWindowStyle ProcessWindowStyle
        {
            get { return cl_ProcessWindowStyle; }
        }

        [ContextProperty("СтильПоляВыбора", "ComboBoxStyle")]
        public ClComboBoxStyle ComboBoxStyle
        {
            get { return cl_ComboBoxStyle; }
        }

        [ContextProperty("СтильСтыковки", "DockStyle")]
        public ClDockStyle DockStyle
        {
            get { return cl_DockStyle; }
        }

        [ContextProperty("СтильШрифта", "FontStyle")]
        public ClFontStyle FontStyle
        {
            get { return cl_FontStyle; }
        }

        [ContextProperty("СтильШтриховки", "HatchStyle")]
        public ClHatchStyle HatchStyle
        {
            get { return cl_HatchStyle; }
        }

        [ContextProperty("СтильЭлементаУправления", "ControlStyles")]
        public ClControlStyles ControlStyles
        {
            get { return cl_ControlStyles; }
        }

        [ContextProperty("ТипДанных", "DataType")]
        public new ClDataType DataType
        {
            get { return cl_DataType; }
        }

        [ContextProperty("ТипСобытияПрокрутки", "ScrollEventType")]
        public ClScrollEventType ScrollEventType
        {
            get { return cl_ScrollEventType; }
        }

        [ContextProperty("ТипСортировки", "SortType")]
        public ClSortType SortType
        {
            get { return cl_SortType; }
        }

        [ContextProperty("ТипЭлементаСетки", "GridItemType")]
        public ClGridItemType GridItemType
        {
            get { return cl_GridItemType; }
        }

        [ContextProperty("ФильтрыУведомления", "NotifyFilters")]
        public ClNotifyFilters NotifyFilters
        {
            get { return cl_NotifyFilters; }
        }

        [ContextProperty("ФлагиМыши", "MouseFlags")]
        public ClMouseFlags MouseFlags
        {
            get { return cl_MouseFlags; }
        }

        [ContextProperty("ФорматированноеПолеВводаПоиск", "RichTextBoxFinds")]
        public ClRichTextBoxFinds RichTextBoxFinds
        {
            get { return cl_RichTextBoxFinds; }
        }

        [ContextProperty("ФорматированноеПолеВводаТипыПотоков", "RichTextBoxStreamType")]
        public ClRichTextBoxStreamType RichTextBoxStreamType
        {
            get { return cl_RichTextBoxStreamType; }
        }

        [ContextProperty("ФорматПикселей", "PixelFormat")]
        public ClPixelFormat PixelFormat
        {
            get { return cl_PixelFormat; }
        }

        [ContextProperty("ФорматПоляКалендаря", "FormatDateTimePicker")]
        public ClFormatDateTimePicker FormatDateTimePicker
        {
            get { return cl_FormatDateTimePicker; }
        }
        
        [ContextMethod("БуферОбмена", "Clipboard")]
        public ClClipboard Clipboard()
        {
            return new ClClipboard();
        }

        [ContextMethod("ВертикальнаяПрокрутка", "VScrollBar")]
        public ClVScrollBar VScrollBar()
        {
            return new ClVScrollBar();
        }

        [ContextMethod("Вкладка", "TabPage")]
        public ClTabPage TabPage(string p1 = null)
        {
            return new ClTabPage(p1);
        }
        
        [ContextMethod("ВключитьВизуальныеСтили", "EnableVisualStyles")]
        public void EnableVisualStyles()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.DoEvents();
        }

        [DllImport("User32")] private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [ContextMethod("ВосстановитьКонсоль", "RestoreConsole")]
        public void RestoreConsole()
        {
            ShowWindow(GetConsoleWindow(), 9);
        }

        [ContextMethod("ВыделенныйДиапазон", "SelectionRange")]
        public ClSelectionRange SelectionRange(IValue p1 = null, IValue p2 = null)
        {
            if ((p1 != null) && (p2 != null))
            {
                return new ClSelectionRange(p1, p2);
            }
            else if ((p1 == null) && (p2 == null))
            {
                return new ClSelectionRange();
            }
            return null;
        }
        
        [ContextMethod("ГлавноеМеню", "MainMenu")]
        public ClMainMenu MainMenu()
        {
            return new ClMainMenu();
        }

        [ContextMethod("ГоризонтальнаяПрокрутка", "HScrollBar")]
        public ClHScrollBar HScrollBar()
        {
            return new ClHScrollBar();
        }

        [ContextMethod("Дерево", "TreeView")]
        public ClTreeView TreeView()
        {
            return new ClTreeView();
        }

        [ContextMethod("ДиалогВыбораКаталога", "FolderBrowserDialog")]
        public ClFolderBrowserDialog FolderBrowserDialog()
        {
            return new ClFolderBrowserDialog();
        }

        [ContextMethod("ДиалогВыбораЦвета", "ColorDialog")]
        public ClColorDialog ColorDialog()
        {
            return new ClColorDialog();
        }

        [ContextMethod("ДиалогВыбораШрифта", "FontDialog")]
        public ClFontDialog FontDialog()
        {
            return new ClFontDialog();
        }

        [ContextMethod("ДиалогОткрытияФайла", "OpenFileDialog")]
        public ClOpenFileDialog OpenFileDialog()
        {
            return new ClOpenFileDialog();
        }

        [ContextMethod("ДиалогСохраненияФайла", "SaveFileDialog")]
        public ClSaveFileDialog SaveFileDialog()
        {
            return new ClSaveFileDialog();
        }

        [ContextMethod("Звук", "Sound")]
        public ClSound Sound()
        {
            return new ClSound();
        }

        [ContextMethod("Значок", "Icon")]
        public ClIcon Icon(IValue p1, IValue p2 = null)
        {
            if (p2 != null)
            {
                return new ClIcon(p1.AsString(), Convert.ToInt32(p2.AsNumber()));
            }
            else
            {
                if (p1.GetType().ToString() == "osf.ClBitmap")
                {
                    Icon Icon1 = new Icon(System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)((ClBitmap)p1.AsObject()).Base_obj.M_Bitmap).GetHicon()));
                    return new ClIcon(Icon1);
                }
                else
                {
                    if (p1.SystemType.Name == "Строка")
                    {
                        return new ClIcon(p1.AsString());
                    }
                }
            }
            return null;
        }
        
        [ContextMethod("ЗначокУведомления", "NotifyIcon")]
        public ClNotifyIcon NotifyIcon([ByRef] IVariable p1)
        {
            ClMenuNotifyIcon p2 = (ClMenuNotifyIcon)(p1.Value);
            return new ClNotifyIcon(ref p2);
        }

        [ContextMethod("Индикатор", "ProgressBar")]
        public ClProgressBar ProgressBar(bool p1)
        {
            return new ClProgressBar(p1);
        }

        [ContextMethod("ИнформацияЗапускаПроцесса", "ProcessStartInfo")]
        public ClProcessStartInfo ProcessStartInfo(string p1 = null, string p2 = null)
        {
            return new ClProcessStartInfo(p1, p2);
        }
        
        [ContextMethod("Календарь", "MonthCalendar")]
        public ClMonthCalendar MonthCalendar()
        {
            return new ClMonthCalendar();
        }

        [ContextMethod("Картинка", "Bitmap")]
        public ClBitmap Bitmap(IValue p1 = null, ClSize p2 = null)
        {
            if (p1 == null && p2 == null)
            {
                return null;
            }
            if (p1 == null && p2 != null)
            {
                return new ClBitmap(p2);
            }
            if (p1 != null && p2 == null)
            {
                string str1 = p1.GetType().ToString();
                if (str1 == "osf.ClBitmap")
                {
                    ClBitmap ClBitmap1 = (ClBitmap)p1.AsObject();
                    Image Image1 = (Image)ClBitmap1.Base_obj;
                    return new ClBitmap(Image1);
                }
                if (str1 == "osf.ClStream")
                {
                    return new ClBitmap((ClStream)p1);
                }
                try
                {
                    if (p1.SystemType.Name == "Строка")
                    {
                        Image Image1 = (Image)new Bitmap(p1.AsString());
                        return new ClBitmap(Image1);
                    }
                }
                catch
                {
                }
            }
            if (p1 != null && p2 != null)
            {
                string str1 = p1.GetType().ToString();
                if (str1 == "osf.ClBitmap")
                {
                    ClBitmap ClBitmap1 = (ClBitmap)p1.AsObject();
                    Image Image1 = (Image)ClBitmap1.Base_obj;
                    return new ClBitmap(Image1, p2);
                }
                if (str1 == "osf.ClStream")
                {
                    ClStream ClStream1 = (ClStream)p1.AsObject();
                    return new ClBitmap(new Image(ClStream1.Base_obj), p2);
                }
                try
                {
                    if (p1.SystemType.Name == "Строка")
                    {
                        Image Image1 = (Image)new Bitmap(p1.AsString());
                        return new ClBitmap(Image1, p2);
                    }
                }
                catch
                {
                }
            }
            return null;
        }
        
        [ContextMethod("Кнопка", "Button")]
        public ClButton Button()
        {
            return new ClButton();
        }

        [ContextMethod("КнопкаПанелиИнструментов", "ToolBarButton")]
        public ClToolBarButton ToolBarButton(string p1 = null)
        {
            return new ClToolBarButton(p1);
        }

        [ContextMethod("Кодировка", "Encoding")]
        public ClEncoding Encoding()
        {
            return new ClEncoding();
        }

        [ContextMethod("Коллекция", "Collection")]
        public ClCollection Collection()
        {
            return new ClCollection();
        }

        [ContextMethod("Колонка", "ColumnHeader")]
        public ClColumnHeader ColumnHeader(string p1 = null, int p2 = 60, int p3 = 0)
        {
            return new ClColumnHeader(p1, p2, p3);
        }
        
        [ContextMethod("КолонкаДанных", "DataColumn")]
        public ClDataColumn DataColumn(string p1 = null, IValue p2 = null)
        {
            if (p1 == null && p2 == null)
            {
                return new ClDataColumn();
            }
            else if (p1 != null && p2 == null)
            {
                return new ClDataColumn(p1);
            }
            else if (p1 != null && p2 != null)
            {
                int type1 = Convert.ToInt32(p2.AsNumber());
                System.Type DataType1 = typeof(System.String);
                if (type1 == 0)
                {
                    DataType1 = typeof(System.String);
                }
                else if (type1 == 1)
                {
                    DataType1 = typeof(System.Decimal);
                }
                else if (type1 == 2)
                {
                    DataType1 = typeof(System.Boolean);
                }
                else if (type1 == 3)
                {
                    DataType1 = typeof(System.DateTime);
                }
                else if (type1 == 4)
                {
                    DataType1 = typeof(System.Object);
                }
                return new ClDataColumn(p1, DataType1);
            }
            return null;
        }

        [ContextMethod("КонтекстноеМеню", "ContextMenu")]
        public ClContextMenu ContextMenu()
        {
            return new ClContextMenu();
        }

        [ContextMethod("Курсор", "Cursor")]
        public ClCursor Cursor()
        {
            return new ClCursor();
        }

        [ContextMethod("Курсоры", "Cursors")]
        public ClCursors Cursors()
        {
            return new ClCursors();
        }

        [ContextMethod("МассивСписок", "ArrayList")]
        public ClArrayList ArrayList(IValue p1 = null)
        {
            if (p1 != null)
            {
                if (p1.SystemType.Name == "Массив")
                {
                    ClArrayList ClArrayList1 = new ClArrayList();
                    ScriptEngine.HostedScript.Library.ArrayImpl ArrayImpl1 = (ScriptEngine.HostedScript.Library.ArrayImpl)p1;
                    for (int i = 0; i < ArrayImpl1.Count(); i++)
                    {
                        ClArrayList1.Add(ArrayImpl1.Get(i));
                    }
                    return ClArrayList1;
                }
                else if (p1 is osf.ClArrayList)
                {
                    return new ClArrayList(((ClArrayList)p1).Base_obj);
                }
            }
            return new ClArrayList();
        }

        [ContextMethod("Математика", "Math")]
        public ClMath Math()
        {
            return new ClMath();
        }

        [ContextMethod("МенюЗначкаУведомления", "MenuNotifyIcon")]
        public ClMenuNotifyIcon MenuNotifyIcon()
        {
            return new ClMenuNotifyIcon();
        }

        [ContextMethod("МетодыОбъекта", "MethodsObj")]
        public string MethodsObj1(IValue p1)
        {
            System.Reflection.MethodInfo[] myMethodInfo = p1.GetType().GetMethods();
            List<string> p = new List<string>();
            for (int i = 0; i < myMethodInfo.Count(); i++)
            {
                if (myMethodInfo[i].CustomAttributes.Count() == 1)
                {
                    if (myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>() != null)
                    {
                        string NameRu = myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>().GetName();
                        string NameEn = myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>().GetAlias();
                        p.Add(NameRu + " (" + NameEn + ")");
                    }
                }
            }
            p.Sort();
            string str1 = "";
            string transfer = "";
            foreach (string str in p)
            {
                str1 = str1 + transfer + str;
                transfer = "\r\n";
            }
            return str1;
        }
        
        [ContextMethod("НаблюдательФайловойСистемы", "FileSystemWatcher")]
        public ClFileSystemWatcher FileSystemWatcher()
        {
            return new ClFileSystemWatcher();
        }

        [ContextMethod("НаборДанных", "DataSet")]
        public ClDataSet DataSet()
        {
            return new ClDataSet();
        }

        [ContextMethod("Надпись", "Label")]
        public ClLabel Label()
        {
            return new ClLabel();
        }

        [ContextMethod("НадписьСсылка", "LinkLabel")]
        public ClLinkLabel LinkLabel()
        {
            return new ClLinkLabel();
        }

        [ContextMethod("НажатьКнопкуМыши", "MouseKeyPress")]
        public void MouseKeyPress(int p1, IValue p2 = null, IValue p3 = null)
        {
            if (p2 != null &&  p3 != null)
            {
                mouse_event(Convert.ToUInt32(p1), Convert.ToInt32(p2.AsNumber()), Convert.ToInt32(p3.AsNumber()), 0, UIntPtr.Zero);
            }
            else
            {
                mouse_event(Convert.ToUInt32(p1), System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y, 0, UIntPtr.Zero);
            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto, SetLastError = true)] private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string WindowName);
        
        [ContextMethod("НайтиОкноПоЗаголовку", "FindWindowByCaption")]
        public IValue FindWindowByCaption(string WindowName)
        {
            IntPtr numWnd = FindWindowByCaption(IntPtr.Zero, WindowName);
            return ValueFactory.Create((int)numWnd);
        }
        
        [ContextMethod("ОбластьСсылки", "LinkArea")]
        public ClLinkArea LinkArea(int p1, int p2)
        {
            return new ClLinkArea(p1, p2);
        }

        [ContextMethod("ОбработкаПослеСобытия", "PostEventProcessing")]
        public void PostEventProcessing()
        {
            if (Event != null)
            {
                ((dynamic)Event).Base_obj.PostEvent();
            }
        }
        
        [ContextMethod("ОкноВвода", "InputBox")]
        public ClInputBox InputBox()
        {
            return new ClInputBox();
        }

        [ContextMethod("ОкноСообщений", "MessageBox")]
        public ClMessageBox MessageBox()
        {
            return new ClMessageBox();
        }

        [ContextMethod("Окружение", "Environment")]
        public ClEnvironment Environment()
        {
            return new ClEnvironment();
        }

        [ContextMethod("ОтправитьКлавиши", "SendKeys")]
        public void SendKeys(string p1)
        {
            System.Windows.Forms.SendKeys.SendWait(p1);
            System.Windows.Forms.Application.DoEvents();
        }
        
        [ContextMethod("Панель", "Panel")]
        public ClPanel Panel()
        {
            return new ClPanel();
        }

        [ContextMethod("ПанельВкладок", "TabControl")]
        public ClTabControl TabControl()
        {
            return new ClTabControl();
        }

        [ContextMethod("ПанельИнструментов", "ToolBar")]
        public ClToolBar ToolBar()
        {
            return new ClToolBar();
        }

        [ContextMethod("ПанельСтрокиСостояния", "StatusBarPanel")]
        public ClStatusBarPanel StatusBarPanel()
        {
            return new ClStatusBarPanel();
        }

        [ContextMethod("ПередатьУправление", "EventControlTransfer")]
        public void EventControlTransfer()
        {
            System.Windows.Forms.Application.DoEvents();
        }

        [ContextMethod("Переключатель", "RadioButton")]
        public ClRadioButton RadioButton()
        {
            return new ClRadioButton();
        }

        [ContextMethod("Перо", "Pen")]
        public ClPen Pen(ClColor p1, IValue p2 = null)
        {
            float _p2;
            if (p2 == null)
            {
                _p2 = 1.0f;
            }
            else
            {
                _p2 = Convert.ToSingle(p2.AsNumber());
            }
            return new ClPen(p1, _p2);
        }
        
        [ContextMethod("Подсказка", "ToolTip")]
        public ClToolTip ToolTip()
        {
            return new ClToolTip();
        }

        [ContextMethod("ПодэлементСпискаЭлементов", "ListViewSubItem")]
        public ClListViewSubItem ListViewSubItem(string p1 = "")
        {
            return new ClListViewSubItem(p1);
        }
        
        [ContextMethod("ПолеВвода", "TextBox")]
        public ClTextBox TextBox()
        {
            return new ClTextBox();
        }

        [ContextMethod("ПолеВыбора", "ComboBox")]
        public ClComboBox ComboBox()
        {
            return new ClComboBox();
        }

        [ContextMethod("ПолеКалендаря", "DateTimePicker")]
        public ClDateTimePicker DateTimePicker()
        {
            return new ClDateTimePicker();
        }

        [ContextMethod("ПолеКартинки", "PictureBox")]
        public ClPictureBox PictureBox()
        {
            return new ClPictureBox();
        }

        [ContextMethod("ПолеСписка", "ListBox")]
        public ClListBox ListBox()
        {
            return new ClListBox();
        }

        [ContextMethod("ПолучитьСобытие", "DoEvents")]
        public IValue DoEvents()
        {
            EventString = "";
            EventHandling();
            if (EventString.Contains("ScriptEngine.HostedScript.Library.DelegateAction"))
            {
                string propName = EventString.Replace("ScriptEngine.HostedScript.Library.DelegateAction", "");
                dynamic obj1 = ((dynamic)Event).Base_obj.Sender.dll_obj;
                PropertyInfo property1 = obj1.GetType().GetProperty(propName);
                return property1.GetValue(obj1);
            }
            else if (EventString.Contains("osf.ClDictionaryEntry"))
            {
                string propName = EventString.Replace("osf.ClDictionaryEntry", "");
                dynamic obj1 = ((dynamic)Event).Base_obj.Sender.dll_obj;
                PropertyInfo property1 = obj1.GetType().GetProperty(propName);
                EventString = ((osf.ClDictionaryEntry)property1.GetValue(obj1)).Value.AsString();
            }
            if (!EventString.Contains("("))
            {
                return ValueFactory.Create((string)EventString + "()");
            }
            return ValueFactory.Create((string)EventString);
        }

        public static void EventHandling()
        {
            while (EventString == "")
            {
                if (EventQueue.Count > 0)
                {
                    dynamic EventArgs1 = (dynamic)EventQueue[0];
                    Event = EventArgs1.dll_obj;
                    EventString = EventArgs1.EventString;
                    EventQueue.RemoveAt(0);
                }
                else
                {
                    WaitMessage();
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }
        //Функция WaitMessage передает управление к другим потокам тогда, когда поток не имеет никаких других сообщений 
        //в своей очереди сообщений. Функция WaitMessage приостанавливает работу потока и не возвращает управление до 
        //тех пор, пока не будет помещено новое сообщение в очередь сообщений потока.
        //При вызове DoEvents в коде, приложение может выполнять другие события. Например, если имеется форма, добавляющая 
        //данные в ListBox, добавление DoEvents в код позволит форме перерисовывается при перетаскивании над ней другого окна. 
        //Если удалить DoEvents из кода, форма не будет перерисовываться до завершения выполнения обработчика события.
        //DoEvents передает управление Windows-у чтобы тот выполнил обработку своих событий
        
        [ContextMethod("ПользовательскийЭлементУправления", "UserControl")]
        public ClUserControl UserControl()
        {
            return new ClUserControl();
        }

        [ContextMethod("Поток", "Stream")]
        public ClStream Stream()
        {
            return new ClStream();
        }

        [ContextMethod("ПотокЧтения", "StreamReader")]
        public ClStreamReader StreamReader(string p1)
        {
            return new ClStreamReader(p1);
        }

        [ContextMethod("ПредставлениеДанных", "DataView")]
        public ClDataView DataView()
        {
            return new ClDataView();
        }

        [ContextMethod("Приложение", "Application")]
        public ClApplication Application()
        {
            return new ClApplication();
        }

        [ContextMethod("Процесс", "Process")]
        public ClProcess Process()
        {
            return new ClProcess();
        }

        [ContextMethod("ПрямоугольнаяКисть", "HatchBrush")]
        public ClHatchBrush HatchBrush(int p1, ClColor p2, ClColor p3)
        {
            return new ClHatchBrush(p1, p2.Base_obj, p3.Base_obj);
        }

        [ContextMethod("Прямоугольник", "Rectangle")]
        public ClRectangle Rectangle(IValue p1 = null, int p2 = 0, int p3 = 0, int p4 = 0)
        {
            if (p1 is osf.ClSize)
            {
                return new ClRectangle(0, 0, ((dynamic)p1).Base_obj.Width, ((dynamic)p1).Base_obj.Height);
            }
            else if (p1 == null)
            {
                int p5 = 0;
                return new ClRectangle(p5, p2, p3, p4);
            }
            else
            {
                int p5 = Convert.ToInt32(p1.AsNumber());
                return new ClRectangle(p5, p2, p3, p4);
            }
        }

        [ContextMethod("Разделитель", "Splitter")]
        public ClSplitter Splitter()
        {
            return new ClSplitter();
        }

        [ContextMethod("Размер", "Size")]
        public ClSize Size(int p1, int p2)
        {
            return new ClSize(p1, p2);
        }

        [ContextMethod("РамкаГруппы", "GroupBox")]
        public ClGroupBox GroupBox()
        {
            return new ClGroupBox();
        }

        [ContextMethod("РегуляторВверхВниз", "NumericUpDown")]
        public ClNumericUpDown NumericUpDown()
        {
            return new ClNumericUpDown();
        }

        [ContextMethod("СвернутьКонсоль", "MinimizedConsole")]
        public void MinimizedConsole()
        {
            ShowWindow(GetConsoleWindow(), 7);
        }

        [ContextMethod("СвойстваКласса", "PropClass")]
        public ClSortedList PropClass(IValue p1)
        {
            ClSortedList ClSortedList1 = new osf.ClSortedList();
            System.Reflection.PropertyInfo[] myPropertyInfo;
            if (p1.GetType() == typeof(osf.ClType))
            {
                myPropertyInfo = p1.GetType().GetProperties();
                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    if (myPropertyInfo[i].CustomAttributes.Count() == 1)
                    {
                        string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetName();
                        string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
                        ClSortedList1.Add(NameEn, ValueFactory.Create(NameEn));
                    }
                }
            }

            if (p1.SystemType.Name == "Строка") // это может быть полное имя класса, если объект не из пространства имен osf, или имя класса сокращенное, если объект из пространства имен osf
            {
                if (p1.AsString().Contains(".")) // имя объекта не из пространства имен osf
                {
                    if (p1.AsString() == "System.Drawing.Bitmap")
                    {
                        myPropertyInfo = (new System.Drawing.Bitmap(10, 10)).GetType().GetProperties();
                    }
                    else
                    {
                        myPropertyInfo = GetTypeFromName(p1.AsString()).GetProperties();
                    }
                    foreach (var item in myPropertyInfo)
                    {
                        if (!ClSortedList1.ContainsKey(item.Name))
                        {
                            ClSortedList1.Add(item.Name, ValueFactory.Create(item.Name));
                        }
                    }
                }
                else // имя объекта из пространства имен osf
                {
                    // находим совпадение GetName или GetAlias в методах osf.OneScriptForms, так мы получим объекты, имеющие конструктор
                    System.Type Type1 = System.Type.GetType("osf.OneScriptForms", false, true);
                    System.Reflection.MethodInfo[] myMethodInfo = Type1.GetMethods();
                    for (int i = 0; i < myMethodInfo.Length; i++)
                    {
                        if (myMethodInfo[i].CustomAttributes.Count() == 1)
                        {
                            if (myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>() != null)
                            {
                                string NameRu = myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>().GetName();
                                string NameEn = myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>().GetAlias();
                                if (NameRu == p1.AsString() || NameEn == p1.AsString())
                                {
                                    System.Type Type2 = System.Type.GetType("osf.Cl" + NameEn, false, true);
                                    System.Reflection.PropertyInfo[] myPropertyInfo2 = Type2.GetProperties();
                                    for (int i2 = 0; i2 < myPropertyInfo2.Length; i2++)
                                    {
                                        if (myPropertyInfo2[i2].CustomAttributes.Count() == 1)
                                        {
                                            string NameRu2 = myPropertyInfo2[i2].GetCustomAttribute<ContextPropertyAttribute>().GetName();
                                            string NameEn2 = myPropertyInfo2[i2].GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
                                            ClSortedList1.Add(NameEn2, ValueFactory.Create(NameEn2));
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else // это объект, а не строка
            {
                myPropertyInfo = p1.GetType().GetProperties();
                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    if (myPropertyInfo[i].CustomAttributes.Count() == 1)
                    {
                        string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetName();
                        string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
                        ClSortedList1.Add(NameEn, ValueFactory.Create(NameEn));
                    }
                }
            }
            return ClSortedList1;
        }
        
        [ContextMethod("СвойстваОбъекта", "PropObj")]
        public string PropObj1(IValue p1)
        {
            string str1 = null;
            string transfer = "";
            List<string> p = new List<string>();
            System.Reflection.PropertyInfo[] myPropertyInfo;
            if (p1.GetType() == typeof(osf.ClType))
            {
                myPropertyInfo = p1.GetType().GetProperties();
                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    if (myPropertyInfo[i].CustomAttributes.Count() == 1)
                    {
                        string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetName();
                        string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
                        p.Add(NameRu + " (" + NameEn + ")");
                    }
                }
            }

            if (p1.SystemType.Name == "Строка") // это может быть полное имя класса, если объект не из пространства имен osf, или имя класса сокращенное, если объект из пространства имен osf
            {
                if (p1.AsString().Contains(".")) // имя объекта не из пространства имен osf
                {
                    myPropertyInfo = GetTypeFromName(p1.AsString()).GetProperties();
                    foreach (var item in myPropertyInfo)
                    {
                        p.Add(item.Name);
                    }
                }
                else // имя объекта из пространства имен osf
                {
                    // находим совпадение GetName или GetAlias в методах osf.OneScriptForms, так мы получим объекты, имеющие конструктор
                    System.Type Type1 = System.Type.GetType("osf.OneScriptForms", false, true);
                    System.Reflection.MethodInfo[] myMethodInfo = Type1.GetMethods();
                    for (int i = 0; i < myMethodInfo.Length; i++)
                    {
                        if (myMethodInfo[i].CustomAttributes.Count() == 1)
                        {
                            if (myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>() != null)
                            {
                                string NameRu = myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>().GetName();
                                string NameEn = myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>().GetAlias();
                                if (NameRu == p1.AsString() || NameEn == p1.AsString())
                                {
                                    System.Type Type2 = System.Type.GetType("osf.Cl" + NameEn, false, true);
                                    System.Reflection.PropertyInfo[] myPropertyInfo2 = Type2.GetProperties();
                                    for (int i2 = 0; i2 < myPropertyInfo2.Length; i2++)
                                    {
                                        if (myPropertyInfo2[i2].CustomAttributes.Count() == 1)
                                        {
                                            string NameRu2 = myPropertyInfo2[i2].GetCustomAttribute<ContextPropertyAttribute>().GetName();
                                            string NameEn2 = myPropertyInfo2[i2].GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
                                            p.Add(NameRu2 + " (" + NameEn2 + ")");
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else // это объект, а не строка
            {
                myPropertyInfo = p1.GetType().GetProperties();
                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    if (myPropertyInfo[i].CustomAttributes.Count() == 1)
                    {
                        string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetName();
                        string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
                        p.Add(NameRu + " (" + NameEn + ")");
                    }
                }
            }
            p.Sort();
            foreach (string str in p)
            {
                str1 = str1 + transfer + str;
                transfer = "\r\n";
            }
            return str1;
        }

        [ContextMethod("СеткаДанных", "DataGrid")]
        public ClDataGrid DataGrid()
        {
            return new ClDataGrid();
        }

        [ContextMethod("СеткаСвойств", "PropertyGrid")]
        public ClPropertyGrid PropertyGrid()
        {
            return new ClPropertyGrid();
        }

        [DllImport("kernel32.dll")] static extern IntPtr GetConsoleWindow();

        [ContextMethod("СкрытьКонсоль", "HideConsole")]
        public void HideConsole()
        {
            ShowWindow(GetConsoleWindow(), 0);
        }

        [ContextMethod("СловарнаяЗапись", "DictionaryEntry")]
        public ClDictionaryEntry DictionaryEntry(IValue p1, IValue p2)
        {
            return new ClDictionaryEntry(p1, p2);
        }

        [ContextMethod("СортированныйСписок", "SortedList")]
        public ClSortedList SortedList()
        {
            return new ClSortedList();
        }

        [ContextMethod("СписокИзображений", "ImageList")]
        public ClImageList ImageList()
        {
            return new ClImageList();
        }

        [ContextMethod("СписокЭлементов", "ListView")]
        public ClListView ListView()
        {
            return new ClListView();
        }

        [ContextMethod("СплошнаяКисть", "SolidBrush")]
        public ClSolidBrush SolidBrush(ClColor p1)
        {
            return new ClSolidBrush(p1.Base_obj);
        }

        [ContextMethod("Ссылка", "Link")]
        public ClLink Link()
        {
            return new ClLink();
        }

        [ContextMethod("СтильКолонкиБулево", "DataGridBoolColumn")]
        public ClDataGridBoolColumn DataGridBoolColumn()
        {
            return new ClDataGridBoolColumn();
        }

        [ContextMethod("СтильКолонкиПолеВвода", "DataGridTextBoxColumn")]
        public ClDataGridTextBoxColumn DataGridTextBoxColumn()
        {
            return new ClDataGridTextBoxColumn();
        }

        [ContextMethod("СтильКолонкиПолеВыбора", "DataGridComboBoxColumnStyle")]
        public ClDataGridComboBoxColumnStyle DataGridComboBoxColumnStyle()
        {
            return new ClDataGridComboBoxColumnStyle();
        }

        [ContextMethod("СтильТаблицыСеткиДанных", "DataGridTableStyle")]
        public ClDataGridTableStyle DataGridTableStyle()
        {
            return new ClDataGridTableStyle();
        }

        [ContextMethod("СтрНайтиМежду", "StrFindBetween")]
        public ClArrayList StrFindBetween(string p1, string p2 = null, string p3 = null, bool p4 = true, bool p5 = true)
        {
            //p1 - исходная строка
            //p2 - подстрока поиска от которой ведем поиск
            //p3 - подстрока поиска до которой ведем поиск
            //p4 - не включать p2 и p3 в результат
            //p5 - в результат не будут включены участки, содержащие другие найденные участки, удовлетворяющие переданным параметрам
            //функция возвращает массив строк
            string str1 = p1;
            int Position1;
            ClArrayList ClArrayList1 = new ClArrayList();
            if (p2 != null && p3 == null)
            {
                Position1 = str1.IndexOf(p2);
                while (Position1 >= 0)
                {
                    ClArrayList1.Add(ValueFactory.Create("" + ((p4) ? str1.Substring(Position1 + p2.Length) : str1.Substring(Position1))));
                    str1 = str1.Substring(Position1 + 1);
                    Position1 = str1.IndexOf(p2);
                }
            }
            else if (p2 == null && p3 != null)
            {
                Position1 = str1.IndexOf(p3) + 1;
                int SumPosition1 = Position1;
                while (Position1 > 0)
                {
                    ClArrayList1.Add(ValueFactory.Create("" + ((p4) ? str1.Substring(0, SumPosition1 - 1) : str1.Substring(0, SumPosition1 - 1 + p3.Length))));
                    try
                    {
                        Position1 = str1.Substring(SumPosition1 + 1).IndexOf(p3) + 1;
                        SumPosition1 = SumPosition1 + Position1 + 1;
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            else if (p2 != null && p3 != null)
            {
                Position1 = str1.IndexOf(p2);
                while (Position1 >= 0)
                {
                    string Стр2;
                    Стр2 = (p4) ? str1.Substring(Position1 + p2.Length) : str1.Substring(Position1);
                    int Position2 = Стр2.IndexOf(p3) + 1;
                    int SumPosition2 = Position2;
                    while (Position2 > 0)
                    {
                        if (p5)
                        {
                            if (Стр2.Substring(0, SumPosition2 - 1).IndexOf(p3) <= -1)
                            {
                                ClArrayList1.Add(ValueFactory.Create("" + ((p4) ? Стр2.Substring(0, SumPosition2 - 1) : Стр2.Substring(0, SumPosition2 - 1 + p3.Length))));
                            }
                        }
                        else
                        {
                            ClArrayList1.Add(ValueFactory.Create("" + ((p4) ? Стр2.Substring(0, SumPosition2 - 1) : Стр2.Substring(0, SumPosition2 - 1 + p3.Length))));
                        }
                        try
                        {
                            Position2 = Стр2.Substring(SumPosition2 + 1).IndexOf(p3) + 1;
                            SumPosition2 = SumPosition2 + Position2 + 1;
                        }
                        catch
                        {
                            break;

                        }
                    }
                    str1 = str1.Substring(Position1 + 1);
                    Position1 = str1.IndexOf(p2);
                }
            }
            return ClArrayList1;
        }

        [ContextMethod("СтрокаСостояния", "StatusBar")]
        public ClStatusBar StatusBar()
        {
            return new ClStatusBar();
        }

        [ContextMethod("ТаблицаДанных", "DataTable")]
        public ClDataTable DataTable(string p1 = null)
        {
            if (p1 == null)
            {
                return new ClDataTable();
            }
            return new ClDataTable(p1);
        }

        [ContextMethod("Таймер", "Timer")]
        public ClTimer Timer()
        {
            return new ClTimer();
        }

        [ContextMethod("ТекстурнаяКисть", "TextureBrush")]
        public ClTextureBrush TextureBrush(IValue p1)
        {
            return new ClTextureBrush(((dynamic)p1).Base_obj);
        }

        [ContextMethod("Тип", "Type")]
        public ClType Type(IValue p1)
        {
            return new ClType(p1);
        }
        
        [ContextMethod("Точка", "Point")]
        public ClPoint Point(int p1, int p2)
        {
            return new ClPoint(p1, p2);
        }

        [ContextMethod("УзелДерева", "TreeNode")]
        public ClTreeNode TreeNode(string p1 = null)
        {
            return new ClTreeNode(p1);
        }
        
        [ContextMethod("УправляемоеСвойство", "ManagedProperty")]
        public ClManagedProperty ManagedProperty(IValue p1, string p2, IValue p3 = null)
        {
            return new ClManagedProperty(p1, p2, p3);
        }
        
        [ContextMethod("Флажок", "CheckBox")]
        public ClCheckBox CheckBox()
        {
            return new ClCheckBox();
        }

        [ContextMethod("Форма", "Form")]
        public ClForm Form()
        {
            return new ClForm();
        }

        [ContextMethod("ФорматИзображения", "ImageFormat")]
        public ClImageFormat ImageFormat()
        {
            return new ClImageFormat();
        }

        [ContextMethod("ФорматированноеПолеВвода", "RichTextBox")]
        public ClRichTextBox RichTextBox()
        {
            return new ClRichTextBox();
        }

        [ContextMethod("ХэшТаблица", "HashTable")]
        public ClHashTable HashTable()
        {
            return new ClHashTable();
        }

        [ContextMethod("Цвет", "Color")]
        public ClColor Color(IValue p1 = null, int p2 = 0, int p3 = 0)
        {
            if (p1 != null)
            {
                if (p1.SystemType.Name == "Строка")
                {
                    ClColor ClColor1 = new ClColor();
                    int NumberProp1 = ClColor1.FindProperty(p1.AsString());
                    dynamic obj1 = ClColor1.GetPropValue(NumberProp1);
                    return (ClColor)ValueFactory.Create(obj1);
                }
                if (p1.SystemType.Name == "Число")
                {
                    Color Color1 = new Color(System.Drawing.Color.FromArgb(Convert.ToInt32(p1.AsNumber()), p2, p3));
                    return new ClColor(Color1);
                }
            }
            return new ClColor();
        }

        [ContextMethod("ЧислоСообщений", "EventQueueCount")]
        public int EventQueueCount()
        {
            return EventQueue.Count;
        }

        [ContextMethod("Шрифт", "Font")]
        public ClFont Font(string p1 = null, IValue p2 = null, int p3 = 0)
        {
            float _p2;
            if (p2 == null)
            {
                _p2 = 6.0f;
            }
            else
            {
                _p2 = Convert.ToSingle(p2.AsNumber());
            }
            return new ClFont(p1, _p2, p3);
        }
        
        [ContextMethod("Экран", "Screen")]
        public ClScreen Screen()
        {
            return new ClScreen();
        }

        [ContextMethod("ЭлементМеню", "MenuItem")]
        public ClMenuItem MenuItem(string p1 = "", string p2 = "", int p3 = 0)
        {
            return new ClMenuItem(p1, p2, p3);
        }
        
        [ContextMethod("ЭлементСписка", "ListItem")]
        public ClListItem ListItem(string p1 = null, IValue p2 = null)
        {
            return new ClListItem(p1, p2);
        }
        
        [ContextMethod("ЭлементСпискаЭлементов", "ListViewItem")]
        public ClListViewItem ListViewItem(string p1 = "", int p2 = -1)
        {
            return new ClListViewItem(p1, p2);
        }
        
        [ContextMethod("ЯчейкаСеткиДанных", "DataGridCell")]
        public ClDataGridCell DataGridCell(int p1, int p2)
        {
            return new ClDataGridCell(p1, p2);
        }

        [ContextMethod("ОтменаАрг", "CancelEventArgs")]
        public ClCancelEventArgs CancelEventArgs()
        {
        	return (ClCancelEventArgs)Event;
        }
        
        [ContextMethod("КолонкаНажатиеАрг", "ColumnClickEventArgs")]
        public ClColumnClickEventArgs ColumnClickEventArgs()
        {
        	return (ClColumnClickEventArgs)Event;
        }
        
        [ContextMethod("КонтекстноеМенюПриПоявленииАрг", "ContextMenuPopupEventArgs")]
        public ClContextMenuPopupEventArgs ContextMenuPopupEventArgs()
        {
        	return (ClContextMenuPopupEventArgs)Event;
        }
        
        [ContextMethod("ЭлементУправленияАрг", "ControlEventArgs")]
        public ClControlEventArgs ControlEventArgs()
        {
        	return (ClControlEventArgs)Event;
        }
        
        [ContextMethod("СобытиеФайловойСистемыАрг", "FileSystemEventArgs")]
        public ClFileSystemEventArgs FileSystemEventArgs()
        {
        	return (ClFileSystemEventArgs)Event;
        }
        
        [ContextMethod("ПриЗакрытииФормыАрг", "FormClosingEventArgs")]
        public ClFormClosingEventArgs FormClosingEventArgs()
        {
        	return (ClFormClosingEventArgs)Event;
        }
        
        [ContextMethod("ЭлементПомеченАрг", "ItemCheckEventArgs")]
        public ClItemCheckEventArgs ItemCheckEventArgs()
        {
        	return (ClItemCheckEventArgs)Event;
        }
        
        [ContextMethod("КлавишаАрг", "KeyEventArgs")]
        public ClKeyEventArgs KeyEventArgs()
        {
        	return (ClKeyEventArgs)Event;
        }
        
        [ContextMethod("КлавишаНажатаАрг", "KeyPressEventArgs")]
        public ClKeyPressEventArgs KeyPressEventArgs()
        {
        	return (ClKeyPressEventArgs)Event;
        }
        
        [ContextMethod("РедактированиеНадписиАрг", "LabelEditEventArgs")]
        public ClLabelEditEventArgs LabelEditEventArgs()
        {
        	return (ClLabelEditEventArgs)Event;
        }
        
        [ContextMethod("СсылкаНажатаАрг", "LinkClickedEventArgs")]
        public ClLinkClickedEventArgs LinkClickedEventArgs()
        {
        	return (ClLinkClickedEventArgs)Event;
        }
        
        [ContextMethod("НадписьСсылкаСсылкаНажатаАрг", "LinkLabelLinkClickedEventArgs")]
        public ClLinkLabelLinkClickedEventArgs LinkLabelLinkClickedEventArgs()
        {
        	return (ClLinkLabelLinkClickedEventArgs)Event;
        }
        
        [ContextMethod("МышьАрг", "MouseEventArgs")]
        public ClMouseEventArgs MouseEventArgs()
        {
        	return (ClMouseEventArgs)Event;
        }
        
        [ContextMethod("РедактированиеНадписиУзлаАрг", "NodeLabelEditEventArgs")]
        public ClNodeLabelEditEventArgs NodeLabelEditEventArgs()
        {
        	return (ClNodeLabelEditEventArgs)Event;
        }
        
        [ContextMethod("РисованиеАрг", "PaintEventArgs")]
        public ClPaintEventArgs PaintEventArgs()
        {
        	return (ClPaintEventArgs)Event;
        }
        
        [ContextMethod("ЗначениеСвойстваИзмененоАрг", "PropertyValueChangedEventArgs")]
        public ClPropertyValueChangedEventArgs PropertyValueChangedEventArgs()
        {
        	return (ClPropertyValueChangedEventArgs)Event;
        }
        
        [ContextMethod("ПереименованиеАрг", "RenamedEventArgs")]
        public ClRenamedEventArgs RenamedEventArgs()
        {
        	return (ClRenamedEventArgs)Event;
        }
        
        [ContextMethod("ПриПрокручиванииАрг", "ScrollEventArgs")]
        public ClScrollEventArgs ScrollEventArgs()
        {
        	return (ClScrollEventArgs)Event;
        }
        
        [ContextMethod("ВыбранныйЭлементСеткиИзмененАрг", "SelectedGridItemChangedEventArgs")]
        public ClSelectedGridItemChangedEventArgs SelectedGridItemChangedEventArgs()
        {
        	return (ClSelectedGridItemChangedEventArgs)Event;
        }
        
        [ContextMethod("КнопкаПанелиИнструментовАрг", "ToolBarButtonClickEventArgs")]
        public ClToolBarButtonClickEventArgs ToolBarButtonClickEventArgs()
        {
        	return (ClToolBarButtonClickEventArgs)Event;
        }
        
        [ContextMethod("ДеревоОтменаАрг", "TreeViewCancelEventArgs")]
        public ClTreeViewCancelEventArgs TreeViewCancelEventArgs()
        {
        	return (ClTreeViewCancelEventArgs)Event;
        }
        
        [ContextMethod("ДеревоАрг", "TreeViewEventArgs")]
        public ClTreeViewEventArgs TreeViewEventArgs()
        {
        	return (ClTreeViewEventArgs)Event;
        }
        
        [ContextMethod("ДанныеДляДизайнера", "DataForDesigner")] // метод нужен только для дизайнера форм
        public string AttributesForDesigner(string p1, string p2) // p1 - строковое представление типа объекта, p2 - имя свойства
        {
            System.Type Type1 = GetTypeFromName(p1);
            string str1 = "";
            string DisplayName = "";//ОтображаемоеИмяСвойства
            //try
            //{
            //    System.ComponentModel.PropertyDescriptor PropertyDescriptorCollection1 = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2];
            //    System.ComponentModel.AttributeCollection attributes = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2].Attributes;
            //    System.ComponentModel.DisplayNameAttribute myDisplayNameAttribute = (System.ComponentModel.DisplayNameAttribute)attributes[typeof(System.ComponentModel.DisplayNameAttribute)];
            //    DisplayName = myDisplayNameAttribute.DisplayName;
            //}
            //catch { }
            str1 = str1 + "DisplayName=" + DisplayName + "~";
            string Description = "";//ОписаниеСвойства
            //try
            //{
            //    System.ComponentModel.PropertyDescriptor PropertyDescriptorCollection1 = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2];
            //    System.ComponentModel.AttributeCollection attributes = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2].Attributes;
            //    System.ComponentModel.DescriptionAttribute myDescriptionAttribute = (System.ComponentModel.DescriptionAttribute)attributes[typeof(System.ComponentModel.DescriptionAttribute)];
            //    Description = myDescriptionAttribute.Description;
            //}
            //catch { }
            str1 = str1 + "Description=" + Description + "~";
            string Category = "";//КатегорияСвойства
            try
            {
                System.ComponentModel.PropertyDescriptor PropertyDescriptorCollection1 = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2];
                System.ComponentModel.AttributeCollection attributes = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2].Attributes;
                System.ComponentModel.CategoryAttribute myCategoryAttribute = (System.ComponentModel.CategoryAttribute)attributes[typeof(System.ComponentModel.CategoryAttribute)];
                Category = myCategoryAttribute.Category;
            }
            catch { }
            str1 = str1 + "Category=" + Category + "~";
            string Browsable = "Неопределено";//ВидимостьСвойства
            try
            {
                System.ComponentModel.PropertyDescriptor PropertyDescriptorCollection1 = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2];
                System.ComponentModel.AttributeCollection attributes = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2].Attributes;
                System.ComponentModel.BrowsableAttribute myBrowsableAttribute = (System.ComponentModel.BrowsableAttribute)attributes[typeof(System.ComponentModel.BrowsableAttribute)];
                Browsable = "" + myBrowsableAttribute.Browsable;
            }
            catch { }
            str1 = str1 + "Browsable=" + Browsable + "~";
            string ConverterTypeName = "";//КонвертерТипаСвойства
            //try
            //{
            //    System.ComponentModel.PropertyDescriptor PropertyDescriptorCollection1 = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2];
            //    System.ComponentModel.AttributeCollection attributes = System.ComponentModel.TypeDescriptor.GetProperties(Type1)[p2].Attributes;
            //    System.ComponentModel.TypeConverterAttribute myTypeConverterAttribute = (System.ComponentModel.TypeConverterAttribute)attributes[typeof(System.ComponentModel.TypeConverterAttribute)];
            //    ConverterTypeName = myTypeConverterAttribute.ConverterTypeName;
            //}
            //catch { }
            str1 = str1 + "ConverterTypeName=" + ConverterTypeName + "~";
            string AvailabilityOfTheProperty = "0";//НаличиеСвойства
            System.Reflection.PropertyInfo[] myPropertyInfo = Type1.GetProperties();
            foreach (var prop in myPropertyInfo)
            {
                if (prop.Name == p2)
                {
                    AvailabilityOfTheProperty = "1";
                    break;
                }
            }
            str1 = str1 + "AvailabilityOfTheProperty=" + AvailabilityOfTheProperty + "~";
            return str1;
        }

        public static System.Type GetTypeFromName(string typeName)
        {
            // необходимо двойное открытие закрытие во избежание проблем
            const string typeProgram = @"using System; using System.Collections.Generic; using System.IO;
                namespace SimpleTest
                {{
                    public class Program
                    {{
                        public static Type GetItemType()
                        {{
                            {0} typeTest = new {0}();
                            if (typeTest == null) return null;
                            return typeTest.GetType();
                        }}
                    }}
                }}";

            var formattedCode = String.Format(typeProgram, typeName);
            var CompilerParams = new System.CodeDom.Compiler.CompilerParameters
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false,
                GenerateExecutable = false,
                CompilerOptions = "/optimize"
            };

            string[] references = { "System.dll", "System.Windows.Forms.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);

            var provider = new Microsoft.CSharp.CSharpCodeProvider();
            System.CodeDom.Compiler.CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, formattedCode);
            if (compile.Errors.HasErrors) return null;

            System.Reflection.Module module = compile.CompiledAssembly.GetModules()[0];
            System.Type mt = null; System.Reflection.MethodInfo methInfo = null;

            if (module != null) mt = module.GetType("SimpleTest.Program");
            if (mt != null) methInfo = mt.GetMethod("GetItemType");
            if (methInfo != null) return (System.Type)methInfo.Invoke(null, null);

            return null;
        }
			
        public static void AddToHashtable(dynamic p1, dynamic p2)
        {
            if (!OneScriptForms.hashtable.ContainsKey(p1))
            {
                OneScriptForms.hashtable.Add(p1, p2);
            }
        }

        public static IValue RevertObj(dynamic initialObject) 
        {
            //ScriptEngine.Machine.Values.NullValue NullValue1;
            //ScriptEngine.Machine.Values.BooleanValue BooleanValue1;
            //ScriptEngine.Machine.Values.DateValue DateValue1;
            //ScriptEngine.Machine.Values.NumberValue NumberValue1;
            //ScriptEngine.Machine.Values.StringValue StringValue1;

            //ScriptEngine.Machine.Values.GenericValue GenericValue1;
            //ScriptEngine.Machine.Values.TypeTypeValue TypeTypeValue1;
            //ScriptEngine.Machine.Values.UndefinedValue UndefinedValue1;

            try
            {
                if (initialObject == null)
                {
                    return (IValue)null;
                }
            }
            catch { }

            try
            {
                string str_initialObject = initialObject.GetType().ToString();
            }
            catch
            {
                return (IValue)null;
            }

            dynamic Obj1 = null;
            string str1 = initialObject.GetType().ToString();
            try
            {
                Obj1 = initialObject.dll_obj;
            }
            catch { }
            if (Obj1 != null)
            {
                return (IValue)Obj1;
            }

            try
            {
                Obj1 = initialObject.M_Object.dll_obj;
            }
            catch { }
            if (Obj1 != null)
            {
                return (IValue)Obj1;
            }
			
            try
            {
                if (str1.Contains("osf."))
                {
                    foreach (System.Collections.DictionaryEntry de in OneScriptForms.hashtable)
                    {
                        if (de.Key.Equals(initialObject.GetType().GetField("M_" + str1.Substring(str1.LastIndexOf(".") + 1)).GetValue(initialObject)))
                        {
                            Obj1 = ((dynamic)de.Value).dll_obj;
                            break;
                        }
                    }
                }
            }
            catch { }
            if (Obj1 != null)
            {
                return (IValue)Obj1;
            }

            try // если initialObject не из пространства имен onescriptgui, то есть Уровень1
            {
                if (!str1.Contains("osf."))
                {
                    string str2 = "osf.Cl" + str1.Substring(str1.LastIndexOf(".") + 1);
                    System.Type TestType = System.Type.GetType(str2, false, true);
                    object[] args = { initialObject };
                    Obj1 = Activator.CreateInstance(TestType, args);
                }
            }
            catch { }
            if (Obj1 != null)
            {
                return (IValue)Obj1;
            }

            try // если initialObject из пространства имен onescriptgui, то есть Уровень2
            {
                if (str1.Contains("osf."))
                {
                    string str3 = str1.Replace("osf.", "osf.Cl");
                    System.Type TestType = System.Type.GetType(str3, false, true);
                    object[] args = { initialObject };
                    Obj1 = Activator.CreateInstance(TestType, args);
                }
            }
            catch { }
            if (Obj1 != null)
            {
                return (IValue)Obj1;
            }

            string str4 = null;
            try
            {
                str4 = initialObject.SystemType.Name;
            }
            catch
            {
                if ((str1 == "System.String") ||
                (str1 == "System.Decimal") ||
                (str1 == "System.Int32") ||
                (str1 == "System.Boolean") ||
                (str1 == "System.DateTime"))
                {
                    return (IValue)ValueFactory.Create(initialObject);
                }
                else if (str1 == "System.Byte")
                {
                    int vOut = Convert.ToInt32(initialObject);
                    return (IValue)ValueFactory.Create(vOut);
                }
                else if (str1 == "System.DBNull")
                {
                    string vOut = Convert.ToString(initialObject);
                    return (IValue)ValueFactory.Create(vOut);
                }
            }
			
            if (str4 == "Неопределено")
            {
                return (IValue)null;
            }
            if (str4 == "Булево")
            {
                return (IValue)initialObject;
            }
            if (str4 == "Дата")
            {
                return (IValue)initialObject;
            }
            if (str4 == "Число")
            {
                return (IValue)initialObject;
            }
            if (str4 == "Строка")
            {
                return (IValue)initialObject;
            }
            return (IValue)initialObject;
        }
			
        public static dynamic DefineTypeIValue(dynamic p1)
        {
            if (p1.GetType() == typeof(ScriptEngine.Machine.Values.StringValue))
            {
                return p1.AsString();
            }
            else if (p1.GetType() == typeof(ScriptEngine.Machine.Values.NumberValue))
            {
                return p1.AsNumber();
            }
            else if (p1.GetType() == typeof(ScriptEngine.Machine.Values.BooleanValue))
            {
                return p1.AsBoolean();
            }
            else if (p1.GetType() == typeof(ScriptEngine.Machine.Values.DateValue))
            {
                return p1.AsDate();
            }
            else
            {
                return p1;
            }
        }
    }
}
