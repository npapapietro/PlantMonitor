   M S B A M L   `   `   `  ����G  CPlantMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PlantMonitorPlantMonitor  5   	       PlantMonitor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PlantMonitor     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��600��6)   .��5	      ]� $��2q�6   .+�5
   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5         m�Name$
 Open��5      $��_Open��6)   68   m� 5      -   5        $
 Save��5      $��_Save��6)   68   m� 5      -   5        $ CloseMW��5      $��_Close��6,   6<   5      5      c� 5   
   -   5        $��	MyToolbar��5      $	��Top=�6#   $
��Auto��68   .@�5      	� -   5        $��GetRectangle��5      ���	#FF969696$��Manage��6F   $
��Auto��6W   $��75��6e    	� 	GroupName$ 
ShapeGroup��6p   6�   �� 5      $��20��6   
������ 6#   �� 5      -   5        $��AddRow��5      ���	#FF969696$��Add Row��6;   $
��Auto��6M   $��75��6[   6f   �� 5      -   5        $��AddCol��5      ���	#FF969696$��Add Col��6;   $
��Auto��6M   $��75��6[   6f   	� 5      -   5        $��RemoveButton��5      ���	#FF969696$��Remove��6F   $
��Auto��6W   $��75��6e   $ 
ShapeGroup��6p   6�   5      (� 5   
   $
��Auto��6   $
��Auto��6   .��5      � -	   5        $��
GlobalGrid��5      $	��570��6%   $
��Auto��61    � ColumnDefinitions 5      �� 5      $	��200 �6'   �� 5      $	��370 �6'    � RowDefinitions 5!      �� 5"      $	��300 �6$   .+�5$      �� 
�������$��2q�6,   
�������._�5%      � $��0��6   $��0��6'    5&      �� 5'      $��25 �6(   �� 5(      $��10 �6(   �� 5)      .+�5+      �� -
   5         ��Name$ 	LeftLabel��5+      $��Overview��6/   $��0��6B   $��0��6R   �� 5,      $��0��6    $��1��60   &   System.Windows.Controls.DataGrid  5-      -   5          Name$ OverviewGrid��5-   #   $��0��6:   $��2��6J   $��10,10,10,10q�6W      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6l      
IsReadOnly . 	   AutoGenerateColumns	 .  
   Columns
 5.      0  *System.Windows.Controls.DataGridTextColumn  5/   "   ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   ��  �� Path$	 Key�  50   "   $ Total Number��65    6K   �� $ Value�52      53      54      � 55      $��1��6   $��0��6'   .+�56      �� -   5        $��CanvasScroll��56   #   $
��Auto=�67   $
��Auto=�6Z   .��57      �� -   5         ��Name$ MyCanvas��57   !   $��62��63   $��62��6?   
�������6�   58      59      5:      5;      5=      5@      