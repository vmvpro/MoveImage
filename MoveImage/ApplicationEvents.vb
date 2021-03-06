﻿
Namespace My

    ' Для MyApplication имеются следующие события:
    ' 
    ' Startup: возникает при запуске приложения перед созданием начальной формы.
    ' Shutdown: возникает после закрытия всех форм приложения. Это событие не происходит при прерывании работы приложения из-за ошибки.
    ' UnhandledException: возникает, если в приложение обнаруживает необработанное исключение.
    ' StartupNextInstance: возникает при запуске приложения, допускающего одновременное выполнение только одной копии, если это приложение уже активно. 
    ' NetworkAvailabilityChanged: возникает при изменении состояния подключения: при подключении или отключении.
    Partial Friend Class MyApplication
        Protected Overrides Function OnStartup(eventArgs As ApplicationServices.StartupEventArgs) As Boolean

#If Not DebugMode Then
            frm_Screensaver.ShowDialog()
#End If




            Return MyBase.OnStartup(eventArgs)

        End Function
    End Class


End Namespace

