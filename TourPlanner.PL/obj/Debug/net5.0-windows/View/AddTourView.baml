   M S B A M L   `   `   `  ����I  ETourPlanner.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TourPlanner.PL.ViewTourPlanner.PL.View  5      P LTourPlanner.Client.BL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullpLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BLTourPlanner.Client.BL.ViewModel 5      %    TourPlanner.PL.View.AddTourView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TourPlanner.PL.View     5      b	viewmodelLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BL     5      $��15(�5        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��10q�6    �� Padding$ 10q�6   $��0��6*   $��Center=�5   	   $��Center=�5   	   
�������$��3q�5   	    �� CornerRadius$ 10��5   	    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      Color$
 Gray��63   ._�5       �  � IsSharedSizeScope$
 True��6    5!      �� 5"      $
��auto �6$   �� 5#      $
��auto �6$   .+�5&      �� $��0��6   $��Center=�5'      $��48(�5(      $��Tour Planner��5)      � 5+      $��1��6   $
��0,20q�6$    5,      �� 5-      $
��auto �6(   �� 5.      $
��auto �6(   �� 5/      $
��auto �6(   �� 50      $
��auto �6(   �� 51      $
��auto �6(   �� 52      $
��auto �6(   �� 53      $
��auto �6(   .+�56      � $��0��6   $
��0,10q�6(    � ColumnDefinitions 57      �� 58      $
��auto �6/   	 z� SharedSizeGroup$	 Label��6<   �� 59      $	��300 �6/   .+�5<      �� $��0��6$   $
��Name��64   �� 5=      $��1��6"   $��20,0,0,0q�62   ��5>      �� *Name+
 �� UpdateSourceTrigger$
 PropertyChanged=�5?      � 5A      $��1��6   $
��0,10q�6(    5B      �� 5C      $
��auto �6/   $	 Label��6<   �� 5D      $	��300 �6/   .+�5G      �� $��0��6$   $
��From��64   �� 5H      $��1��6"   $��20,0,0,0q�62   ��5I      �� *From+$
 PropertyChanged=�5J      � 5L      $��2��6   $
��0,10q�6(    5M      �� 5N      $
��auto �6/   $	 Label��6<   �� 5O      $	��300 �6/   .+�5R      �� $��0��6$   $��To��64   �� 5S      $��1��6"   $��20,0,0,0q�62   ��5T      �� *To+$
 PropertyChanged=�5U      � 5W      $��3��6   $
��0,10q�6(    5X      �� 5Y      $
��auto �6/   $	 Label��6<   �� 5Z      $	��300 �6/   .+�5]      �� $��0��6$   $��Description��64   �� 5^      $��1��6"   $��20,0,0,0q�62   ��5_      �� *Description+$
 PropertyChanged=�5`      �� 5c      $��4��6   $
��0,10q�6*   $	��100��68   $��Center=�5d      $	��Add��5f       �� 	IsDefault$
 True��5g      ��5e      �� *
AddCommand+5g      �� 5i      $��6��6    $��0,10,0,0q�6-   $��Center=�5j      
���  �� � DataContext 5k      �� *MessageViewModel+��5m      �� *	Message+y�5n      �� *
HasMessage+ �� 	Converter# [  5o      5p      5q      �� 5s   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5t      �� $��10q�6   $	��200��6!   $��Go Home��6-   $��Go Home��6e   ��6?   �� *UpdateViewCommand+6e   5u      5v      5y      