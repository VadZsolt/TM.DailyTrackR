   M S B A M L   `   `   `  ����R  NTM.DailyTrackR.DataType, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:TM.DailyTrackR.DataType;assembly=TM.DailyTrackR.DataTypeTM.DailyTrackR.DataType  5   	    TM.DailyTrackR.View&    TM.DailyTrackR.View.CreateWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ]
convertersFclr-namespace:TM.DailyTrackR.DataType;assembly=TM.DailyTrackR.DataType     5   	     � Title$  Create New Activity��5   	    � Icon$ new.ico��5   	   $	��400��5   	   $	��400��5   	   $	��400��5	   	   $	��400��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5      *   $TM.DailyTrackR.DataType.EnumConverts   EnumConverter.   (TM.DailyTrackR.DataType.AnyFieldHasValue  AnyFieldHasValue  StyledTextBlock �� 
TargetType �� Property �� Value  StyledComboBox  StyledTextBox  StyledDatePicker(  "System.Windows.Controls.DatePicker  StyledButton��%y  &	        &	      &	 &     &	 �     &	 �    &	 *    &	       5   
   6"     5   
   6&   �� 5   
   " ��6(   .�5      ��  � ��$ 16(�6)   �� 5       � ��
 ���_�6+   �� 5       � ��$ 10q�6'   �� 5       � ��$ DemiBold"�6+   5      �� 5   
   " ��6'   .�5      ��  � ��$ 14(�6)   �� 5       � ��
 �   �6+   �� 5       � ��$ 10q�6'   �� 5       � ��$	 200��6&   5      �� 5   
   " ��6&   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ 10q�6'   �� 5       � ��$	 200��6&   5      �� 5    
   "  6)   .�5!      ��  � ��$ 14(�6)   �� 5"       � ��
 �OO/�6+   �� 5#       � ��
 �����6+   �� 5$       � ��$ 10q�6'   �� 5%       � ��$	 200��6&   5&      �� 5'   
   " ��6%   .�5(      ��  � ��$ 16(�6)   �� 5)       � ��
 ��  �6+   �� 5*       � ��
 �����6+   �� 5+       � ��$ Right=�64   �� 5,       � ��$ Bottom=�62   �� 5-       � ��$ 10q�6'   �� 5.       � ��$	 100��6&   5/      50      .��51      �  � RowDefinitions 52   
   �� 53      $
��Auto �6   �� 54      $
��Auto �6   �� 55      $
��Auto �6   �� 56      $
��Auto �6   �� 57      $
��Auto �6   �� 58      $��* �6    � ColumnDefinitions 5:   
   �� 5;      $	��100��6   �� 5<      $
��Auto �6   .+�5?   
   �� $��Project Type:��6   $��0��6)   $��0��66   #��[ 6F   �� 5@   
   -   5        	 ��Name$	 ProjectTypeComboBox��5@      $��0��60   $��1��6=   #��[ 6M   �� 5B   
   $��
Task Type:��6   $��1��6&   $��0��63   #��[ 6C   �� 5C   
   -   5        $	 TaskTypeComboBox��5C      $��1��6-   $��1��6:   #��[ 6J   �� 5E   
   $��Description:��6   $��2��6(   $��0��65   #��[ 6E   �� 5F   
   -   5        
 ��Name$
 DescriptionTextBox��5F      $��2��6.   $��1��6;   #��[ 6K   �� 5H   
   $��Status:��6   $��3��6#   $��0��60   #��[ 6@   �� 5I   
   -   5        $	 StatusComboBox��5I      $��3��6+   $��1��68   #��[ 6H   �� 5K   
   $��Date:��6   $��4��6!   $��0��6.   #��[ 6>     5L   
   -   5          Name$ 
DatePicker��5L      $��4��6)   $��1��66   #��[ 6F   �� 5N   
   -   5        $
��Save��5N      $��5��69   $��1��6F   #��[ 6V   {�5O      `� 5P       `� 	Converter# [ 6   .1�5Q      ��  �� ElementName$ ProjectTypeComboBox��6    �� Path$ SelectedItem�6@   �� 5R      $ TaskTypeComboBox��6   $ SelectedItem�6=   �� 5S      $ DescriptionTextBox��6   $
 Text�6?   �� 5T      $ StatusComboBox��6   $ SelectedItem�6;   �� 5U      $ 
DatePicker��6   $ SelectedDate�67   5V      5X      5Y      5Z      