   M S B A M L   `   `   `  ����?  ;RPM1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RPM1RPM1  5   	       RPM1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:RPM1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��10q�6"   .+�5      �� $��0,0,0,10q�6    �� Padding$ 0q�6'      GradientBackground#���   5      ._�5      �� -   5         ��Name$ TextBox1��5       �� AcceptsReturn$
 True��6,   " �� VerticalScrollBarVisibility$
 Auto=�6A   $��10q�5      
������ 6'   5      �� 5      $��0,0,0,10q�6   $ 0q�6'   #���   5      ._�5      �� -   5        $ TextBox2��5      $
 True��6,   $
 Auto=�6A   $��10q�5      
������ 6'   5      �� 5      -   5         ��Name$ FontStyleCombo��5      $��0,0,0,10q�6b   .@�5      �� $��Arial��6   �� 5      $��Courier New��6   �� 5      $��Verdana��6   5      5       �� 5"   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5#      �� -   5        $��Открыть��5#      $��5q�6'     ButtonStyle#��[ 5$      �� 5%      -   5        $��Очистить��5%      $��5q�6(   #��[ 5&      �� 5'      -   5         ��Name$ CloseButton��5(   L   $��Закрыть��5'      $��5q�6'   #��[ 5(      ${�False��6:   6L   5)      5*      5+      