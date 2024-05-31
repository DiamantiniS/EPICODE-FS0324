import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { User } from '../../models/user.model';
import { TodoService } from '../../services/todo.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrl: './todos.component.scss',
})
export class TodosComponent implements OnInit {
  todos: Todo[] = [];
  users: User[] = [];

  constructor(
    private todoService: TodoService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.todos = this.todoService.getTodos();
    this.users = this.userService.getUsers();
  }

  getUserName(userId: number): string {
    const user = this.users.find((user) => user.id === userId);
    return user ? `${user.firstName} ${user.lastName}` : 'Unknown';
  }

  getUserImage(userId: number): string {
    const user = this.users.find((user) => user.id === userId);
    return user ? user.image : '';
  }

  toggleTodoStatus(todo: Todo): void {
    this.todoService.updateTodoStatus(todo.id, !todo.completed);
  }
}
