   M S B A M L   `   `   `  ����T  PForeignLanguagesSchoolApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ForeignLanguagesSchoolApp.pagesForeignLanguagesSchoolApp.pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6C   7    1ForeignLanguagesSchoolApp.pages.ClientServicePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:ForeignLanguagesSchoolApp.pages     5      6sys&clr-namespace:System;assembly=mscorlib     6C     N� Title$  ClientServicePage��5	       � 	Resources 5         defaultImage��%X   &	        ��5   
   62pack://application:,,,/images/logo/beauty_logo.png��5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��59* �6   �� 5      $
��375* �6   �� 5      $	��65* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $
��Left=�6I   $��10,0,0,0q�6d   $��26��6v   .+�5      �� $%��Сервисы клиента: ��6   $��Comic Sans MS)�61   $��20(�6L   �� 5      -   5         ��Name$ TbClientInfo��5      $��Comic Sans MS)�6.   $��20(�6I   5      �� 5   
   -   5         ��Name$ spServiceInfo��5      $��0,52,0,0q�6,   $��2��6>   �� 5   
   -   5         ��Name$ LViewService��5      $��1��6)   $��5,5,5,5q�66   ��5      �� 5        �� 
TargetType" ��6   .�5!      ��  �� Property � ��	 �� Value$	 Stretch=�6C   5"      ��5$      �� 5%      .R�5&      �� 
���   �$��1q�61   ._�5'      � 
 � ColumnDefinitions
 5(      �� 5)   "   $	��200 �63   �� 5*   "   $��* �63   .+�5-      �� $	��180��6$   $	��100��60   $��5q�6=   ��6H   ��  �� Path$ Service.ImgPath� �� FallbackValue# [  �� 5/      $��1��6)   $��5q�69   .+�50   "   �� $
��Bold"�6P   ��6,   �� $ Service.Title�6P   �� 51   "   $ 
Horizontal=�6-   .+�52   &   �� $��Strikethrough{�6W   ��60   �� $ Service.CostText�6W   �� 53   &   ��60   �� $ Service.DiscountCost� �� StringFormat$  {0} руб. за ���� 54   &   ��60   �� $ Service.DurationInMin�$ {0} минут��55   #   �� 56   "   ��6,   �� $ Service.DiscountText�57      58      59      5:      5<      �� 5=   
   -   5        
���   ����#04a0ff
������� � Cursor$
 Hand��5=   N   $��Обновить��6\   $��Right=�6o   $	��120��6�   $��32��6�   $��0,4,16,4q�6�   $��2��6�   6�   5>      5?      