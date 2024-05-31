import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { User } from '../../models/user.model';
import { TodoService } from '../../services/todo.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-completed-todos',
  templateUrl: './completed-todos.component.html',
  styleUrl: './completed-todos.component.scss',
})
export class CompletedTodosComponent implements OnInit {
  todos: Todo[] = [];
  users: User[] = [];

  constructor(
    private todoService: TodoService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.todos = this.todoService.getTodos().filter((todo) => todo.completed);
    this.users = this.userService.getUsers();
  }

  getUserName(userId: number): string {
    const user = this.users.find((user) => user.id === userId);
    return user ? `${user.firstName} ${user.lastName}` : 'Unknown';
  }

  toggleTodoStatus(todo: Todo): void {
    this.todoService.updateTodoStatus(todo.id, !todo.completed);
  }
  getUserImage(userId: number): string {
    const user = this.users.find((user) => user.id === userId);
    return user ? user.image : '';
  }
}
