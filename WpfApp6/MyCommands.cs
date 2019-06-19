using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp6
{
    class MyCommands
    {
        private static RoutedUICommand addPackage;
        private static RoutedUICommand showPackageDetails;
        private static RoutedUICommand closeDialog;
        private static RoutedUICommand saveChanges;
        private static RoutedUICommand deletePackage;
        private static RoutedUICommand printDetails;
        private static RoutedUICommand accept;

        static MyCommands() {
            addPackage = new RoutedUICommand(
                "Add Package", "AddPackage", typeof(MyCommands));
            addPackage.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));

            showPackageDetails = new RoutedUICommand(
                "Show Package Details", "ShowPackageDetails", typeof(MyCommands));
            showPackageDetails.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));

            closeDialog = new RoutedUICommand(
                "Close Dialog", "CloseDialog", typeof(MyCommands));
            closeDialog.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));

            saveChanges = new RoutedUICommand(
                "Save Changes", "SaveChanges", typeof(MyCommands));
            saveChanges.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));

            deletePackage = new RoutedUICommand(
                "Delete Package", "DeletePackage", typeof(MyCommands));
            deletePackage.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));

            printDetails = new RoutedUICommand(
                "Print Details", "PrintDetails", typeof(MyCommands));
            printDetails.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));

            accept = new RoutedUICommand(
                "Accept Warning", "Accept", typeof(MyCommands));
            accept.InputGestures.Add(new MouseGesture(MouseAction.LeftClick));

        }

        public static RoutedUICommand AddPackage {
            get { return addPackage; }
        }

        public static RoutedUICommand ShowPackageDetails {
            get { return showPackageDetails; }
        }

        public static RoutedUICommand CloseDialog {
            get { return closeDialog; }
        }

        public static RoutedUICommand SaveChanges {
            get { return saveChanges; }
        }

        public static RoutedUICommand DeletePackage {
            get { return deletePackage; }
        }

        public static RoutedUICommand PrintDetails {
            get { return printDetails; }
        }

        public static RoutedUICommand Accept {
            get { return accept; }
        }
    }
}
