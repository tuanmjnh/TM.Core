using System;
namespace TM.Core.Helpers {
    //Message
    public static class Message {
        public static void success(this Microsoft.AspNetCore.Mvc.Controller controller, string message) {
            controller.TempData["MsgSuccess"] = message;
        }
        public static void info(this Microsoft.AspNetCore.Mvc.Controller controller, string message) {
            controller.TempData["MsgInfo"] = message;
        }
        public static void warning(this Microsoft.AspNetCore.Mvc.Controller controller, string message) {
            controller.TempData["MsgWarning"] = message;
        }
        public static void danger(this Microsoft.AspNetCore.Mvc.Controller controller, string message) {
            controller.TempData["MsgDanger"] = message;
        }
    }
}