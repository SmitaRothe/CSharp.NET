   M S B A M L   `   `   `  ����H  DTravelAppExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TravelAppExamTravelAppExam  5   	       TravelAppExam.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TravelAppExam     5   	   -   5          � Title$
  Trip��5   	   $��431.289��6   $��911.342��6'   .��5	      � $��0,0,3.8,-0.4q�6   .+�5
   
   �� -   5        $��lvList��5
      $
��Left=�6!   $	��312��6<   $��	10,65,0,0q�6I   $	��Top=�6\   $	��490��6t    �� View 5      �� 5      -   5        GrdList��.P�5      �� $��Destination��6R    �� Width$	 130��6g    �� DisplayMemberBinding 6%   �� *Destination+6g   �� 5      $
��Name��6K   $	 100��6Y    6%   �� *Name+6Y   �� 5      $��Passport��6O   $ 60��6a    6%   �� *
Passport+6a   �� 5      $��	Departure��6P   $	 100��6c    6%   �� *	Departure+6c   �� 5      $��Return��6M   $	 100��6]    6%   �� *Return+6]   5      5      �� 5   
   -   5        $��btnSaveSelected��5      $��Save Selected��6(   $
��Left=�6@   $��
157,21,0,0q�6[   $	��Top=�6o   $	��145��6�   $��17��6�   6�   �� 5   
   $��Destination��6   $
��Left=�6&   $��
524,10,0,0q�6A   $	��Top=�6U    J� RenderTransformOrigin$ 0.765,1.155&�6m   $��64��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��
524,65,0,0q�6:   $	��Top=�6N   $��87��6f   �� 5   
   $��Passport��6   $
��Left=�6#   $��524,118,0,0q�6>   $	��Top=�6S   $��90��6k   �� 5   
   $��	Departure��6   $
��Left=�6$   $��524,183,0,0q�6?   $	��Top=�6T   $��64��6l   �� 5   
   $��Return��6   $
��Left=�6!   $��524,238,0,0q�6<   $	��Top=�6Q   $��64��6i   �� 5   
   -   5        $��txtDestination��5      $
��Left=�6(   $��23��6C   $��
631,13,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6x   $	��243��6�   �� 5   
   -   5        $��txtName��5      $
��Left=�6!   $��23��6<   $��
631,67,0,0q�6H   $
 Wrap=�6\   $	��Top=�6q   $	��243��6�   �� 5   
   -   5        $��txtPassport��5      $
��Left=�6%   $��23��6@   $��631,118,0,0q�6L   $
 Wrap=�6a   $	��Top=�6v   $	��243��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDepartureDate��5      $
��Left=�6,   $��631,185,0,0q�6G   $	��Top=�6\   $	��230��6t     5   
   -	   5        $��dpReturnDate��5      $
��Left=�6)   $��631,238,0,0q�6D   $	��Top=�6Y   $	��230��6q   �� 5!   
   -
   5        $��
btnAddtrip��5!      $��Add trip��6#   $
��Left=�66   $��Center=�6Q   $��561,359,0,0q�6u   $	��Top=�6�   $��75��6�   6�   �� 5"   
   -   5        $��btnDeletetrip��5"      $��Delete trip��6&   $
��Left=�6<   $��667,359,0,0q�6W   $	��Top=�6l   $��75��6�   {�.  6�   �� 5#   
   -   5        $��btnUpdatetrip��5#      $��Update trip��6&   $
��Left=�6<   $��786,358,0,0q�6W   $	��Top=�6l   $��75��6�   {�.  6�   5(      5)      