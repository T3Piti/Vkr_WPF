   M S B A M L   `   `   `  ����B  >Vkr_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Vkr_WPF.Views.WindowsVkr_WPF.Views.Windows  5   	   &     Vkr_WPF.Views.Windows.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Vkr_WPF.Views.Windows     5   	     � Title$  Главное окно��5   	   $	��450��6   $	��800��6+   ���#33334C���#DBDBEA$0��*/Vkr_WPF;component/Fonts/#Natural Mono Alt)�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5         NavigationButtonsStyle �� 
TargetType �� Property �� Value��%d  &	        �� 5   
   " ��6/   .�5      ��  � ��$ 50��6'   �� 5       � ��$ 20(�6)   �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�60   �� 5       � �� �#DBDBEA6+   �� 5       � ��$ Center=�69   �� 5       � ��$ Stretch=�6;   �� 5       � ��$ 30,0,0,0q�6(   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5       � RowDefinitions 5   
   �� 5       $��75 �6   �� 5!      .+�5$   
   � $��0��6   $��0��6   ���#2A2A36.+�5%      �� $��Center=�5&      $
��Left=�6/   ���#DBDBEA$��22(�5(      $��20,0,0,0q�5)      ��5%      �� *
UserName+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�5)      5*      �� 5,   
    �� Orientation$ Vertical=�6   $��1��6,   $��0��69   .+�5-      �� $��Проекты��6   #��[  6'   ��5.      �� *ShowProjectsListPageCommand+�� 5/      $��Документация��6   #��[  6,   ��50      �� *ShowDocumentsListPageCommand+�� 51      $��Регистрация��6   #��[  6+   ��52      �� *ShowRegistrationPageCommand+�� 53      $��
Выход��6   #��[  6%   ��54      �� *CloseWindowCommand+55      � 57   
   $��0��6   $��1��6   ���#BBD4EA.+�58      �� $��Center=�59      $��Center=�63   $��30(�6P   ���#0D0D2E��58      �� *
PageName+$	 TwoWay=�$
 PropertyChanged=�5:      5;       � 5<   
   $��1��6   $��1��6   
���������5=      �� *CurrentPage+$	 TwoWay=�$
 PropertyChanged=�5>      5?      