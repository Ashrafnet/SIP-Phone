using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Softphone
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="control">The  control which rise this event</param>
    public delegate void OnDialogResult(UserControl control);

    /// <summary>
    /// for sort listview
    /// </summary>
    /// <param name="columnIndex">The index of the sorted column</param>
    /// <param name="item1">The first list view item to compare with the other list view item</param>
    /// <returns>As the compare method return</returns>
    public delegate int SortListView(int columnIndex, ListViewItem item1, ListViewItem item2);

    /// <summary>
    /// for Key pad control
    /// </summary>
    /// <param name="keyPad"></param>
    public delegate void KeypadPressed(char keyPad);

    public delegate void BalanceLoad(string Balance);

    public delegate void Regestering();

    public delegate void SettingChanged(string propertyName);

    public delegate void SuccessLogin(Control control);

    public delegate void DataLoaded();


    public delegate void OnDialedButtonPressed();

    public delegate void OnCancelButtonPressed();

    public delegate void OnPhonebookSelectedContacts(List<string> numbers);
}
