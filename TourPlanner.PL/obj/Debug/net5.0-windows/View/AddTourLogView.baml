   M S B A M L   `   `   `  ����I  ETourPlanner.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TourPlanner.PL.ViewTourPlanner.PL.View  5      P LTourPlanner.Client.BL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullpLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BLTourPlanner.Client.BL.ViewModel 5      (    "TourPlanner.PL.View.AddTourLogView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TourPlanner.PL.View     5      b	viewmodelLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BL     5      $��15(�5        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��10q�6    �� Padding$ 10q�6   $��0��6*   $��Center=�5   	   $��Center=�5   	   
�������$��3q�5   	    �� CornerRadius$ 10��5   	    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      Color$
 Gray��63   ._�5!      �  � IsSharedSizeScope$
 True��6    5"      �� 5#      $
��auto �6$   �� 5$      $
��auto �6$   .+�5'      �� $��0��6   $��Center=�5(      $��48(�5)      $��Tour Planner��5*      � 5,      $��1��6   $
��0,20q�6$    5-      �� 5.      $
��auto �6(   �� 5/      $
��auto �6(   �� 50      $
��auto �6(   �� 51      $
��auto �6(   �� 52      $
��auto �6(   �� 53      $
��auto �6(   �� 54      $
��auto �6(   .+�57      � $��0��6   $
��0,10q�6(    � ColumnDefinitions 58      �� 59      $
��auto �6/   	 z� SharedSizeGroup$	 Label��6<   �� 5:      $	��300 �6/   .+�5=      �� $��0��6$   $��
Difficulty��64   �� 5>      $��1��6"   $��20,0,0,0q�62   ��5?      �� *
Difficulty+
 �� UpdateSourceTrigger$
 PropertyChanged=�5@      � 5B      $��1��6   $
��0,10q�6(    5C      �� 5D      $
��auto �6/   $	 Label��6<   �� 5E      $	��300 �6/   .+�5H      �� $��0��6$   $��Datatime��64   �� 5I      $��1��6"   $��20,0,0,0q�62   ��5J      �� *
DateTime+$
 PropertyChanged=�5K      � 5M      $��2��6   $
��0,10q�6(    5N      �� 5O      $
��auto �6/   $	 Label��6<   �� 5P      $	��300 �6/   .+�5S      �� $��0��6$   $��Comment��64   �� 5T      $��1��6"   $��20,0,0,0q�62   ��5U      �� *	Comment+$
 PropertyChanged=�5V      � 5X      $��3��6   $
��0,10q�6(    5Y      �� 5Z      $
��auto �6/   $	 Label��6<   �� 5[      $	��300 �6/   .+�5^      �� $��0��6$   $��Rating��64   �� 5_      $��1��6"   $��20,0,0,0q�62   ��5`      �� *Rating+$
 PropertyChanged=�5a      � 5c      $��4��6   $
��0,10q�6(    5d      �� 5e      $
��auto �6/   $	 Label��6<   �� 5f      $	��300 �6/   .+�5i      �� $��0��6$   $��Duration��64   �� 5j      $��1��6"   $��20,0,0,0q�62   ��5k      �� *TotalDuration+$
 PropertyChanged=�5l      �� 5o      $��5��6   $
��0,10q�6*   $	��100��68   $��Center=�5p      $	��Add��5s       �� 	IsDefault$
 True��5t      ��5q      �� *DataContext.AddCommand+ �� RelativeSource �� *FindAncestor+ �� AncestorType" >���5r      �� 5t      �� 5v      $��6��6    $��0,10,0,0q�6-   $��Center=�5w      
���  �� � DataContext 5x      �� *MessageViewModel+��5z      �� *	Message+y�5{      �� *
HasMessage+ �� 	Converter# [  5|      5}      5~      �� 5�   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5�      �� $��10q�6   $	��200��6!   $��Go Home��6-   $��Go Home��6e   ��6?   �� *UpdateViewCommand+6e   5�      5�      5�      