import { CanDeactivate } from '@angular/router';
import { UserEditComponent } from '../users/user-edit/user-edit.component';

export class PreventUnsavedChangesGuard implements CanDeactivate<UserEditComponent> {
    canDeactivate(component: UserEditComponent) {
        if(component.editForm.dirty){
            return confirm('Uwaga, niezapisane zmiany zostaną utracone!');
        }
        return true;
    }
}