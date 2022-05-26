function on-error {
    if (!$?) {
        Write-Error $1
    }
}

function clean {
    dotnet clean Convertly.sln
}

function build {
    dotnet build --nologo -c Release Convertly.sln

    on-error "Build Failed. See above."
}

function test {
    dotnet test --nologo --no-build -c Release Convertly.sln

    on-error "Tests Failed. See above."
}

function pack {
    # package the output
}

clean
build
test
pack