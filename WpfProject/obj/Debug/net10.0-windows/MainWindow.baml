   M S B A M L   `   `   `  ����  
WpfProject    EmployeeApp.MainWindow   5   	   X TPresentationCore, Version=10.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35] YPresentationFramework, Version=10.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35f bSystem.Windows.Controls.Ribbon, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089S OWindowsBase, Version=10.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   S OSystem.Xaml, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$1  +Регистрация сотрудника��5   	   $	��450��6(   $	��800��65   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   �� $��10q�6   .+�5      �� $��Имя:��6   �� 5      -   5         ��Name$ txtName��5      �� 5      $ ��Дата рождения:��6   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
dpBirthday��5      �� 5      $��Пол:��6   �� 5      -   5         ��Name$ 	cmbGender��5      .@�5      �� $��Не выбрано��6    �� 
IsSelected$
 True��64   �� 5      $
��MALE��6   �� 5      $��FEMALE��6   5      �� 5      $��Образование:��6   �� 5      -   5        $ cmbEducation��5      .@�5      �� $��Не выбрано��6   $
 True��64   �� 5      $��PRIMARY��6   �� 5      $��	SECONDARY��6   �� 5       $��SPECIALIZED_SECONDARY��6   �� 5!      $��HIGHER��6   5"      �� 5$      $��Должность:��6   �� 5%      -   5        $ cmbPosition��5%      .@�5&      �� $��Не выбрано��6   $
 True��64   �� 5'      $��DIRECTOR��6   �� 5(      $��MANAGER��6   �� 5)      $��JUNIOR��6   �� 5*      $��MIDDLE��6   �� 5+      $��SENIOR��6   5,      �� 5.      $��Зарплата:��6   �� 5/      -   5        $ 	txtSalary��5/      6)   �� 51      $��Премия:��6   �� 52      -   5         ��Name$ txtBonus��52      �� 54      -   5        $��Добавить��54      $
��0,10q�6B   �� 55      -	   5        $$��Сохранить в файл��55      $
��0,10q�6I   �� 56      -
   5        $ txtError��56      
���  ��6*   57      &   System.Windows.Controls.DataGrid  59   
   -   5          Name$ dgEmployees��59   #   $��1��6      AutoGenerateColumns$ False��68   $��10q�6T   ��6`   �� *	employees+	   Columns	 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Имя��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *name+  5<      $
 Дата рождения��6%    6<   �� *
birthday+ �� StringFormat$ d��  5=      $
 Пол��6%    62   �� *gender+  5>      $
 Образование��6%    6:   �� *	education+  5?      $
 Должность��6%    68   �� *
position+  5@      $
 Зарплата��6%    67   �� *salary+$ N2��  5A      $
 Премия��6%    65   �� *bonus+$ N2��  5B      $#
 Полная зарплата��6%    6>   �� *
FullSalary+$ N2��5D      5E      5F      