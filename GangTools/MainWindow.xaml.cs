using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GangTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DatePicker_Start.SelectedDate = new DateTime(2014, 01, 20);
            DatePicker_End.SelectedDate = new DateTime(2014, 01, 20);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //инициализируем каждую смену отдельно стартовыми значениями
            Gang gang1 = new Gang();
            gang1.GangLeader = "Игнатов";
            //стартовые даты для того чтобы поставить на рельсы кратные 12-часам циклы смен
            gang1.CurrentDateTimeStart = new DateTime(2014, 03, 19, 08, 00, 00);

            Gang gang2 = new Gang();
            gang2.GangLeader = "Дымов";
            gang2.CurrentDateTimeStart = new DateTime(2014, 03, 20, 08, 00, 00);

            Gang gang3 = new Gang();
            gang3.GangLeader = "Голощапов";
            gang3.CurrentDateTimeStart = new DateTime(2014, 03, 21, 08, 00, 00);

            Gang gang4 = new Gang();
            gang4.GangLeader = "Патютько";
            gang4.CurrentDateTimeStart = new DateTime(2014, 03, 22, 08, 00, 00);

            List<Gang> gangs = new List<Gang>();
            gangs.Add(gang1);
            gangs.Add(gang2);
            gangs.Add(gang3);
            gangs.Add(gang4);

            // из формы DatePicker выбранные пользователем в отдельные переменные
            DateTime startTd = (DateTime)DatePicker_Start.SelectedDate;
            DateTime endTd = (DateTime)DatePicker_End.SelectedDate;
            int shiftsCounter = 0;

            //подогнать циклы всех смен под выбранную пользователем дату
            foreach (Gang gang in gangs)
            {
                //пока дата начала смены от начальной инициализации меньше даты начала, выбранной пользователем, прибавляем смены
                while (gang.CurrentDateTimeStart < startTd)
                {
                    gang.addOneShiftPre();//добавить смену
                }
                //записать стартовые даты в отдельную переменную класса для дальнейшего вывода пользователю
                gang.FirstDateTimeStart = gang.CurrentDateTimeStart;
            }

            /* startTd - дата начала, выбранная пользователем
             * endTd - дата окончания, выбранная пользователем
             * цикл работает пока startTd меньше endTd
             */
            while (startTd < endTd)
            {
                //перебираются значения каждой смены
                foreach (Gang gang in gangs)
                {
                    //если текущая симулируемая дата меньше даты окончания, добавить смену (внутри класса счетчик смен +1)
                    if (gang.CurrentDateTimeStart.DayOfYear <= endTd.DayOfYear)
                    {
                        gang.addOneShift();
                    }
                }

                //обновляем условие while (+12 часов):
                startTd = startTd.AddHours(12);
            }

            ListView_ShiftsSummary.ItemsSource = gangs;
        }


    }
}
