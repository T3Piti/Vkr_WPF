   M S B A M L   `   `   `  ����B  >Vkr_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Vkr_WPF.Views.PagesVkr_WPF.Views.Pages  5      +    %Vkr_WPF.Views.Pages.DocumentsListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Vkr_WPF.Views.Pages     5        N� Title$  DocumentsListPage��5	       N� 
FontFamily$0 */Vkr_WPF;component/Fonts/#Natural Mono Alt)�5
       � 	Resources 5         TextBoxStyle �� Property �� Value��%+  &	        �� 5   
   .�5      ��  � ��
 ���� 68   �� 5       � ��$ Center=�6F   �� 5       � ��$ 0q�6=   �� 5       � ��$ 5q�65   �� 5       � �� �#DBDBEA68   �� 5       � ��$ 20(�66   �� 5       � ��$	 280��63   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Документы��6   $��5q�5      $��10q�5       $��20(�5!      $��Center=�5"      $��Stretch=�5#      
������ ���#0D0D2E5%      �� 5&       �� CornerRadius$ 15��6   ���#0D0D2E$	��300��5(      $��50��5)      $��10q�5*      ._�5+      � .+�5,      �� $��1��6    �� 5-      -   5         ��Name$ SearchDocumentsBox��5.      #��[  5-      ��5/      �� *SearchDocument+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=��� 50       J� IsHitTestVisible .  $#��Поиск документа��51       $��Center=�52       $
��Left=�53       
�������$��13(�55        �� Padding$ 5q�56       $��10,0,0,0q�57       ��58      �� 59       �� 
TargetType" ��6$    �� Triggers 5:   "   �� 5;   &    �� Binding 62   �� *Text+ �� ElementName$ SearchDocumentsBox�� �� Value  6k   .a�5<   *   ��  � y�$ Visible=�6G   5=   '   .�5?   "   ��  � y�$ Hidden=�6?   5@      5B      5C      5D      5E      �� 5H   
   $��1��6   
������ $	��200��5K      $��2q�5L      $��10q�5M      $	��Top=�5N      ��5I      �� *DocumentsList+$
 TwoWay=�$	 PropertyChanged=� �� SelectedItem 5J      �� *SelectedDocument+$
 TwoWay=�$	 PropertyChanged=���5O      �� 5P      .R�5Q      �  � Orientation$ Vertical=�6     K� IsItemsHost . 67   5R      ��5T      �� 5U      .R�5V      �� $ 30��6   ���#1A0C2C$	��300��5X      $	��150��5Y      $��10q�5Z      ._�5[      � .+�5\      �� $��1��6(   �� 5]      .+�5^   "   �� $��5q�5_   $   $��10,5,5,0q�5`   $   $��20(�5a   $   $��Center=�5b   $   $��Stretch=�5c   $   
������ ���#DBDBEA��5^   (   ��  �� Path$
 name�5e   $   �� 5f   "   $��5q�5g   $   $��10,5,5,0q�5h   $   $��20(�5i   $   $��Center=�5j   $   $��Stretch=�5k   $   
������ ���#DBDBEA��5f   (   �� $
 date�5m   $   5n      5o      5p      5q       � ContextMenu 5s      �� 5t      .@�5u      m� $��Просмотреть��6    m� Command 5v      �� *ShowDocumentWindowCommand+m� 5w      $��Удалить��6    5x      �� *DeleteDocumentCommand+5y      5{      5|      5}      